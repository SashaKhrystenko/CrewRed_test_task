USE master;
GO

CREATE DATABASE Taxi;
GO

USE Taxi;
GO

CREATE TABLE TaxiTripRecords(
	tpep_pickup_datetime DATETIME NOT NULL,
	tpep_dropoff_datetime DATETIME NOT NULL,
	passenger_count INT NOT NULL,
	trip_distance FLOAT NOT NULL,
	store_and_fwd_flag NVARCHAR(3) NOT NULL,
	PULocationID INT NOT NULL,
	DOLocationID INT NOT NULL,
	fare_amount DECIMAL(14,2) NOT NULL,
	tip_amount DECIMAL(14,2) NOT NULL

	PRIMARY KEY (tpep_pickup_datetime, tpep_dropoff_datetime, passenger_count)
);
GO

CREATE NONCLUSTERED INDEX INDEX_TaxiTrip_TipAmount
ON TaxiTripRecords (tip_amount DESC);
GO

CREATE NONCLUSTERED INDEX INDEX_TaxiTrip_TripDistance
ON TaxiTripRecords (trip_distance DESC)
INCLUDE (tpep_pickup_datetime, tpep_dropoff_datetime, passenger_count, store_and_fwd_flag, PULocationID, DOLocationID, fare_amount, tip_amount);
GO

CREATE NONCLUSTERED INDEX INDEX_TaxiTrip_TravelTime
ON TaxiTripRecords (tpep_pickup_datetime, tpep_dropoff_datetime);
GO

CREATE NONCLUSTERED INDEX INDEX_TaxiTrip_PULocationID_TripDistance
ON TaxiTripRecords (PULocationID, trip_distance)
INCLUDE (tpep_pickup_datetime, tpep_dropoff_datetime, passenger_count, fare_amount, tip_amount, DOLocationID);