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


CREATE PROCEDURE OrderReportAllTime
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
GO

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
GO
