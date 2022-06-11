USE [master]
GO

CREATE DATABASE weatherforecast
GO

USE [weatherforecast]
GO


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
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

INSERT INTO [WeatherForecast] VALUES (GETDATE(), 20, 'Teste 1')
INSERT INTO [WeatherForecast] VALUES (GETDATE(), 22, 'Teste 2')
INSERT INTO [WeatherForecast] VALUES (GETDATE(), 15, 'Teste 3')
INSERT INTO [WeatherForecast] VALUES (GETDATE(), 35, 'Teste 4')


USE [master]
GO
ALTER DATABASE [weatherforecast] SET  READ_WRITE 
GO
