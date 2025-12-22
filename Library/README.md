# Library Management System

Проект системы управления библиотекой для лабораторных работ по курсу "Разработка корпоративных приложений".

## Технологии
- **Backend:** .NET 8, ASP.NET Core
- **База данных:** MongoDB
- **Доступ к данным:** EF Core + провайдер MongoDB.EntityFrameworkCore
- **Коммуникация:** HTTP API (контроллеры ASP.NET Core), gRPC
- **Оркестрация и локальная разработка:** .NET Aspire
- **Маппинг моделей:** AutoMapper
- **Тестирование:** xUnit, Bogus

## Доменная область
Система управления библиотекой с учётом:
- Каталога книг
- Читателей
- Выдачи книг
- Статистики популярности

## Структура решения

Решение разделено на слои (Domain -> Application -> Infrastructure -> API Host) и отдельный хост оркестрации Aspire.

### Library.Api.Host
ASP.NET Core Web API приложение, предоставляющее HTTP API.

Содержит:
- Контроллеры CRUD по каждой сущности:
  - `BookController`
  - `PublisherController`
  - `ReaderController`
  - `RentalController`
- `AnalyticsController` для аналитических запросов
- Базовый контроллер `CrudControllerBase<TDto, TCreateUpdateDto, TKey>` с типовой реализацией CRUD-эндпоинтов
- `RentalStreamingService` — фоновый сервис (gRPC клиент) для получения сгенерированных контрактов аренды, использующий `IOptions<RentalStreamingOptions>` для конфигурации
- `Program.cs` с настройкой DI, маршрутизации и инфраструктуры API (Swagger/логирование/health checks - по конфигурации проекта)

### Library.AppHost
Хост .NET Aspire для локальной разработки и запуска всей системы как набора сервисов.

Содержит:
- Aspire-конфигурацию приложения
- Создание контейнера MongoDB
- Подключение и запуск `Library.Api.Host` как сервиса
- Подключение и запуск `Library.RentalGenerator` как сервиса
- Конфигурацию зависимостей/переменных окружения для сервисов через Aspire

### Library.RentalGenerator
Отдельный gRPC сервис для генерации тестовых данных.

Содержит:
- `RentalGeneratorService` — реализация gRPC сервера с bidirectional streaming
- Генерацию случайных данных с использованием библиотеки Bogus
- Конфигурацию параметров генерации (размер батча, задержка) через паттерн `IOptions<RentalGenerationOptions>` и `appsettings.json`

### Library.Application
Слой приложения с реализациями бизнес-сценариев и CRUD-операций.

Содержит:
- Сервисы CRUD для каждой сущности (реализации `IApplicationService<TDto, TCreateUpdateDto, TKey>`)
- `AnalyticsService` (реализация `IAnalyticsService`) для аналитических запросов
- Использование репозиториев из слоя Infrastructure и маппинга DTO <-> Entity через AutoMapper

### Library.Application.Contracts
Контракты слоя приложения.

Содержит:
- DTO-модели:
  - `*Dto` для получения сущностей
  - `*CreateUpdateDto` для создания/обновления сущностей
- DTO для аналитики (например, популярность книг/издательств)
- Интерфейсы:
  - `IApplicationService<TDto, TCreateUpdateDto, TKey>`
  - `IAnalyticsService`
- Профиль AutoMapper `LibraryProfile` для конфигурации маппинга
- `Protos/rental.proto` — определение gRPC сервиса и сообщений для генерации контрактов

### Library.Infrastructure.EfCore
Слой доступа к данным на базе EF Core провайдера MongoDB.

Содержит:
- `LibraryDbContext` (MongoDB.EntityFrameworkCore)
- Репозитории для сущностей (реализации `IRepository<TEntity, TKey>`)
- Маппинг коллекций MongoDB, настройки конвертеров и конфигурацию моделей

### Library.Domain
Доменный слой с основными сущностями и доменными правилами.

Содержит:
- Сущности домена (`Book`, `Publisher`, `Reader`, `Rental`) и перечисления (enum) статусов/типов
- Интерфейс репозитория `IRepository<TEntity, TKey>` для абстракции доступа к данным
- `DataSeeder` для наполнения тестовыми/демо-данными (обновлён и приведён к актуальной структуре слоёв)

### Library.ServiceDefaults
Общий проект с "дефолтами" сервиса.

Обычно содержит:
- Общие настройки логирования/трассировки/метрик
- Health checks
- Расширения для конфигурации сервисов и единый подход к инфраструктурным настройкам

## Тестирование
Тесты (xUnit) проверяют корректность выборок и аналитических запросов на подготовленных данных.