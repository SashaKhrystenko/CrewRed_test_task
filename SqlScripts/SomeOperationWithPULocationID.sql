USE TestTask;
GO

SELECT TOP 100 *
FROM SampleData
WHERE PULocationId = 7 AND trip_distance > 10