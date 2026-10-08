## Шорт суммари

Веб-приложение для пациентов клиники: регистрация и личный кабинет, 
запись на приём к врачу или на услугу, просмотр медицинской истории 
и дополнительных возможностей, связанных с основными сценариями. 
Проект реализован как набор микросервисов на ASP.NET Core, 
общающихся между собой асинхронно через RabbitMQ.

## Архитектура для каждого микросервиса:

Program.cs > DI > Controllers > Services > Repositories > EF Core > Database

## Доп Инфа:

__DdContext__ - объект EF Core, через который C# работает с базой данных.
EF Core > переводит LINQ/C# в SQL.
типа, _dbContext.Offices - дай доступ к таблице Offices

## Nuget пакеты:
Microsoft.EntityFrameworkCore - сам EF Core

Npgsql.EntityFrameworkCore.PostgreSQL - провайдер PostgreSQL

Microsoft.EntityFrameworkCore.Design - для миграции

## Отдельно:

Services:
1. RabiitMQ
2. MinIO