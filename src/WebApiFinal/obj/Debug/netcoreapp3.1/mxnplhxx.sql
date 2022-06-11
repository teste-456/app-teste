IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [WeatherForecast] (
    [WeatherForecastId] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [TemperatureC] int NOT NULL,
    [Summary] nvarchar(max) NULL,
    CONSTRAINT [PK_WeatherForecast] PRIMARY KEY ([WeatherForecastId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211012021052_Initial', N'5.0.10');
GO

COMMIT;
GO

