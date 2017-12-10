--DROP PROCEDURE GetOrderReport

--CREATE PROCEDURE GetOrderReport2 @id int
--AS
--SELECT * from zakaz
--inner join land on land.id = zakaz.land_id
--inner join customer on customer.id = land.customer_id
--inner join designer on designer.id = zakaz.designer_id
--inner join zakaz_difficulties on zakaz_difficulties.zakaz_id = zakaz.id
--inner join difficulties on difficulties.id = zakaz_difficulties.difficulties_id
--inner join work on work.zakazId = zakaz.id
--where zakaz.id = @id
--GO

--declare @id int
--set @id = 16
--exec GetOrderReport2 @id

CREATE PROCEDURE AvgOrderReportYear
AS
SELECT AVG(zakaz.price) as AvgPrice,
	   AVG(land.size) as AvgLandSize,
	   Max(zakaz.price) as MaxPrice,
	   Max(land.size) as MaxLandSize,
	   Min(zakaz.price) as MinPrice,
	   Min(land.size) as MinLandSize
from zakaz
inner join land on land.id = zakaz.land_id
inner join customer on customer.id = land.customer_id
inner join designer on designer.id = zakaz.designer_id
where zakaz.start_time >= DATEADD(year, YEAR(GETDATE()) - 1, CAST('0001-01-01' AS DATE))
GO

declare @id int
set @id = 16
exec GetOrderReport2 @id


CREATE PROCEDURE OrderReportYear
AS
SELECT 
	   AVG(land.size) as AvgLandSize,
	   Max(land.size) as MaxLandSize,
	   Min(land.size) as MinLandSize,
	   AVG(work.countt) as AvgWorkCount,
	   Max(work.countt) as MaxWorkCount,
	   Min(work.countt) as MinWorkCount
from zakaz
inner join land on land.id = zakaz.land_id
left join work on work.zakazId = zakaz.id
where zakaz.start_time >= DATEADD(year, YEAR(GETDATE()) - 1, CAST('0001-01-01' AS DATE))
GO

drop procedure OrderReportMonth
CREATE PROCEDURE OrderReportMonth
AS
SELECT 
	   AVG(land.size) as AvgLandSize,
	   Max(land.size) as MaxLandSize,
	   Min(land.size) as MinLandSize,
	   AVG(work.countt) as AvgWorkCount,
	   Max(work.countt) as MaxWorkCount,
	   Min(work.countt) as MinWorkCount
from zakaz
inner join land on land.id = zakaz.land_id
left join work on work.zakazId = zakaz.id
where zakaz.start_time >= DATEADD(year, Month(GETDATE()) - 1, CAST('0001-01-01' AS DATE))
GO


--drop PROCEDURE CustomerReportMonth
CREATE PROCEDURE CustomerReportMonth @name varchar(36), @surname varchar(36)
As
select  Count(zakaz.id) as ZakazCount
from designer 
left join zakaz on zakaz.designer_id = designer.id
where (designer.name Like(@name+'%') And designer.surname Like(@surname+'%') ) And
zakaz.start_time >= DATEADD(year, Month(GETDATE()) - 1, CAST('0001-01-01' AS DATE))
Go

--drop PROCEDURE ExtraOrderReportMonth
CREATE PROCEDURE ExtraOrderReportMonth
@minLandSize int
as
select  Max(land.size) as MaxLandSize,
		Min(land.size) as MinLandSize,
		Avg(land.size) as AvgLandSize,
		Max(zakaz.start_time) as MaxStartTime,
		Min(zakaz.start_time) as MinStartTime,
		COUNT(zakaz.id) as ZakazCount
from zakaz
inner join land on land.id = zakaz.land_id
where zakaz.start_time >= DATEADD(month, -1, GETDATE()) AND	
land.size >= @minLandSize
go

--drop PROCEDURE ExtraOrderReport
CREATE PROCEDURE ExtraOrderReport
@minLandSize int
as
select  Max(land.size) as MaxLandSize,
		Min(land.size) as MinLandSize,
		Avg(land.size) as AvgLandSize,
		Max(zakaz.start_time) as MaxStartTime,
		Min(zakaz.start_time) as MinStartTime,
		COUNT(zakaz.id) as ZakazCount
from zakaz
inner join land on land.id = zakaz.land_id
AND	
land.size >= @minLandSize
go

--drop PROCEDURE ExtraOrderReportYear
CREATE PROCEDURE ExtraOrderReportYear
@minLandSize int
as
select  Max(land.size) as MaxLandSize,
		Min(land.size) as MinLandSize,
		Avg(land.size) as AvgLandSize,
		Max(zakaz.start_time) as MaxStartTime,
		Min(zakaz.start_time) as MinStartTime,
		COUNT(zakaz.id) as ZakazCount
from zakaz
inner join land on land.id = zakaz.land_id
where zakaz.start_time >= DATEADD(YEAR, -1, GETDATE())
AND	
land.size >= @minLandSize
go

select *
from zakaz
inner join land on land.id = zakaz.land_id