USE TestTask;
GO

SELECT TOP 100 *,
DATEDIFF(SECOND, tpep_pickup_datetime, tpep_dropoff_datetime) AS TravelTime
FROM SampleData
ORDER BY TravelTime DESC;