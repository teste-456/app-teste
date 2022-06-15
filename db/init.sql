use weather
go

CREATE TABLE `weather`.`WeatherForecast` (
  `WeatherForecastId` INT NOT NULL,
  `Date` DATETIME NOT NULL,
  `TemperatureC` INT NOT NULL,
  `TemperatureF` INT NOT NULL,
  `Summary` VARCHAR(100) NULL,
  PRIMARY KEY (`WeatherForecastId`));

insert into WeatherForecast values (1, now(), 10, 12, 'temp 1');
insert into WeatherForecast values (2, now(), 11, 13, 'temp 2');
insert into WeatherForecast values (3, now(), 12, 14, 'temp 3');



