CREATE TABLE  designer (
    id int NOT NULL IDENTITY (1,1),
    name varchar(36) NOT NULL,
    surname varchar(36) NOT NULL,
	 dateOfBirth Date Not Null,
	PRIMARY KEY (id)
);

--alter table designer 
--drop column age 
--alter table designer 
--add  dateOfBirth Date Not Null

--CREATE TABLE  designer_priceList (
--    id int NOT NULL,
--    designer_id int NOT NULL,
--    price_per_hour int NOT NULL,
--    PRIMARY KEY (id),
--	FOREIGN KEY (designer_id) REFERENCES designer(id)
--);

CREATE TABLE  customer (
    id int NOT NULL IDENTITY (1,1),
    name varchar(36) NOT NULL,
    surname varchar(36) NOT NULL,
	dateOfBirth Date Not Null,
	PRIMARY KEY (id)
);

--alter table customer 
--drop column dateOfBirth 
--alter table customer 
--add  dateOfBirth Date Not Null
--delete customer where customer.id = 

CREATE TABLE  land (
    id int NOT NULL IDENTITY (1,1),
    name varchar(36) NOT NULL,
	customer_id int NOT NULL,
	size int Not null,
	PRIMARY KEY (id),
	FOREIGN KEY (customer_id) REFERENCES customer(id)
);

--drop table difficulties
-- Trash Contaminated water

CREATE TABLE  difficulties (
    id int NOT NULL IDENTITY (1,1),
    subj varchar(36) NOT NULL,
	price int Not Null,
	PRIMARY KEY (id)
);

alter table difficulties
drop column zakazId

--CREATE TABLE  customer_land (
--    customer_id int NOT NULL,
--    land_id int NOT NULL,
--	FOREIGN KEY (customer_id) REFERENCES customer(id),
--	FOREIGN KEY (land_id) REFERENCES land(id)
--);

--drop table zakaz_difficulties

CREATE TABLE  zakaz_difficulties (
    difficulties_id int NOT NULL,
    zakaz_id int NOT NULL,
	FOREIGN KEY (difficulties_id) REFERENCES difficulties(id),
	FOREIGN KEY (zakaz_id) REFERENCES zakaz(id),
	primary key (difficulties_id, zakaz_id)
);

CREATE TABLE  zakaz (
	id int NOT NULL IDENTITY (1,1),
    designer_id int NOT NULL,
    land_id int NOT NULL,
	price int NOT NULL,
	start_time DATE NOT NULL,
	end_time DATE NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (designer_id) REFERENCES designer(id),
	FOREIGN KEY (land_id) REFERENCES land(id)
);

--Alter table work
--ADD  price int Not NULL
--drop table work

CREATE TABLE  work (
    id int NOT NULL IDENTITY (1,1),
    typee varchar(36) NOT NULL,
	countt int NOT NULL,
	price int Not NULL,
	zakazId int Not Null,
	PRIMARY KEY (id),
	FOREIGN KEY (zakazId) REFERENCES zakaz(id)
);

--drop table zakaz_work

--CREATE TABLE  zakaz_work (
--    zakazs_id int NOT NULL,
--    work_id int NOT NULL ,
--	FOREIGN KEY (zakazs_id) REFERENCES zakaz(id),
--	FOREIGN KEY (work_id) REFERENCES work(id),
--	primary key (zakazs_id, work_id)
--);











--DROP PROCEDURE GetOrderReport
--DROP PROCEDURE GetOrderReport

CREATE PROCEDURE GetOrderReport @id int,
 @OrderId int Output, @start_time Date Output, @end_time Date Output,
 @DesignerName varchar(36) output,  @DesignerSurname varchar(36) output,
 @CustomerName varchar(36) output,  @CustomerSurname varchar(36) output
AS
SELECT @OrderId = zakaz.id, 
	   @start_time = zakaz.start_time,  @end_time = zakaz.end_time,
	   @DesignerName = designer.name, @DesignerSurname = designer.surname,
	   @CustomerName = customer.name, @CustomerSurname = customer.surname
from zakaz
inner join land on land.id = zakaz.land_id
inner join customer on customer.id = land.customer_id
inner join designer on designer.id = zakaz.designer_id
inner join zakaz_difficulties on zakaz_difficulties.zakaz_id = zakaz.id
inner join difficulties on difficulties.id = zakaz_difficulties.difficulties_id
inner join work on work.zakazId = zakaz.id
where zakaz.id = @id
GO

declare @OrderId int
declare @id int
declare @start_time Date
set @id = 16
set @OrderId = 2
exec GetOrderReport @id,  @OrderId output , @start_time output
select id = @OrderId, startTime = @start_time




declare @count int
select @count = Count(difficulties.id)
from zakaz 
left join zakaz_difficulties on zakaz_difficulties.zakaz_id = zakaz.id
inner join difficulties on difficulties.id = zakaz_difficulties.difficulties_id
group by zakaz.id

select  AVG(land.size) as AvgLandSize,
		Max(land.size) as MaxLandSize,
		Min(land.size) as MinLandSize,
		AVG((work.countt)) as AvgWorkCount,
		Max((work.countt)) as MaxWorkCount,
		Min((work.countt)) as MinWorkCount
from zakaz 
left join work on work.zakazId = zakaz.id
inner join land on land.id = zakaz.land_id
