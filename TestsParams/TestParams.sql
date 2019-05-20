if not exists (select * from sys.databases where name = 'testParams')
	begin
		create database testParams
	end;
GO

use testParams

if OBJECT_ID('Tests', 'U') is null
	begin
		create table Tests 
		(
			TestId INT primary key identity,
			TestDate smalldatetime not null,
			BlockName Nvarchar(50) not null,
			Note Nvarchar(200)				
		)
	end;
		
if OBJECT_ID('Parameters', 'U') is null
	begin
		create table Parameters 
		(
			ParametrId INT primary key identity,
			TestId INT not null,
			ParameterName Nvarchar(200) not null,
			RequiredValue Decimal not null,
			MeasuredValue Decimal not null,
			Foreign key (TestId) references Tests (TestId) on delete cascade
		)
	end;