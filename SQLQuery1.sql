CREATE TABLE  designer (
    id int NOT NULL IDENTITY (1,1),
    name varchar(36) NOT NULL,
    surname varchar(36) NOT NULL,
	age int NOT NULL,
	PRIMARY KEY (id)
);

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
	age int NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE  land (
    id int NOT NULL IDENTITY (1,1),
    name varchar(36) NOT NULL,
	customer_id int NOT NULL,
	size int Not null,
	PRIMARY KEY (id),
	FOREIGN KEY (customer_id) REFERENCES customer(id)
);

CREATE TABLE  difficulties (
    id int NOT NULL IDENTITY (1,1),
    subj varchar(36) NOT NULL,
	price int Not Null,
	PRIMARY KEY (id)
);

--CREATE TABLE  customer_land (
--    customer_id int NOT NULL,
--    land_id int NOT NULL,
--	FOREIGN KEY (customer_id) REFERENCES customer(id),
--	FOREIGN KEY (land_id) REFERENCES land(id)
--);

CREATE TABLE  land_difficulties (
    difficulties_id int NOT NULL,
    land_id int NOT NULL,
	FOREIGN KEY (difficulties_id) REFERENCES difficulties(id),
	FOREIGN KEY (land_id) REFERENCES land(id)
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

CREATE TABLE  work (
    id int NOT NULL IDENTITY (1,1),
    typee varchar(36) NOT NULL,
	countt int NOT NULL,
	price int Not NULL,
	PRIMARY KEY (id)
);

--drop table zakaz_work

CREATE TABLE  zakaz_work (
    zakazs_id int NOT NULL,
    work_id int NOT NULL ,
	FOREIGN KEY (zakazs_id) REFERENCES zakaz(id),
	FOREIGN KEY (work_id) REFERENCES work(id),
	primary key (zakazs_id, work_id)
);