use master
drop database PROVIDER

create database PROVIDER



go

use PROVIDER
---------CLIENTS
create table Clients 
(
	ID int IDENTITY(1,1) primary key,
	Username varchar(30) not null,
	Name varchar(30) not null,
	Surname varchar(30) not null,
)

INSERT INTO [dbo].[clients] VALUES ('Stefan123','Stefan','Aleksandric')
INSERT INTO [dbo].[clients] VALUES ('Vlade123','Vladimir','Vukcevic')
INSERT INTO [dbo].[clients] VALUES ('Dare123','Darko','Bjelicic')
INSERT INTO [dbo].[clients] VALUES ('Fico123','Filip','Despotovic')
INSERT INTO [dbo].[clients] VALUES ('Tina123','Kristina','Stojkovic')

select *
from Clients

--DROP TABLE Clients

---------INTERNET_PLAN
create table Internet_Plan 
(
	ID int IDENTITY(1,1) primary key,
	Download_Speed int not null,
	Upload_Speed int not null
)

INSERT INTO [dbo].[Internet_Plan] VALUES (100,50)
INSERT INTO [dbo].[Internet_Plan] VALUES (200,100)
INSERT INTO [dbo].[Internet_Plan] VALUES (300,150)
INSERT INTO [dbo].[Internet_Plan] VALUES (500,250)
INSERT INTO [dbo].[Internet_Plan] VALUES (1000,500)

select *
from Internet_Plan

--DROP TABLE Internet_Plan

---------TV_PLAN
create table TV_Plan 
(
	ID int IDENTITY(1,1) primary key,
	Channel_Number int not null
)

INSERT INTO [dbo].[TV_Plan] VALUES (100)
INSERT INTO [dbo].[TV_Plan] VALUES (200)
INSERT INTO [dbo].[TV_Plan] VALUES (300)
INSERT INTO [dbo].[TV_Plan] VALUES (500)
INSERT INTO [dbo].[TV_Plan] VALUES (1000)

select *
from TV_Plan

--DROP TABLE TV_Plan

---------COMBINED_PLAN
create table Combo_Plan 
(
	ID int IDENTITY(1,1) primary key,
	Internet_Plan_ID int,
	TV_Plan_ID int
)

INSERT INTO [dbo].[Combo_Plan] VALUES (1,1)
INSERT INTO [dbo].[Combo_Plan] VALUES (2,2)
INSERT INTO [dbo].[Combo_Plan] VALUES (3,3)
INSERT INTO [dbo].[Combo_Plan] VALUES (4,4)
INSERT INTO [dbo].[Combo_Plan] VALUES (5,5)
INSERT INTO [dbo].[Combo_Plan] VALUES (1,5)

select *
from Combo_Plan

--DROP TABLE Combo_Plan

---------PLANS

create table Plans
(
	ID int IDENTITY(1,1) primary key,
	Name varchar(30) not null,
	Price float not null,
	Internet_Plan_ID int,
	TV_Plan_ID int,
	Combo_Plan_ID int
)

INSERT INTO [dbo].[Plans] VALUES ('NET 100',1000,1,NULL,NULL)
INSERT INTO [dbo].[Plans] VALUES ('TV 100',500,NULL,1,NULL)
INSERT INTO [dbo].[Plans] VALUES ('COMBO 100',1200,NULL,NULL,1)
INSERT INTO [dbo].[Plans] VALUES ('NET 300',3000,3,NULL,NULL)

select *
from Plans

--DROP TABLE Plans

---------CLIENT_PLANS_Activated

create table Clients_Plans_Activated
(
	Client_ID int,
	Plan_ID int

	primary key (Client_ID, Plan_ID)
)

INSERT INTO [dbo].[Clients_Plans_Activated] VALUES (1,1)
INSERT INTO [dbo].[Clients_Plans_Activated] VALUES (2,2)
INSERT INTO [dbo].[Clients_Plans_Activated] VALUES (3,3)

select *
from Clients_Plans_Activated

--DROP TABLE Clients_Plans_Activated

---------Prices_Plans

create table Prices
(
	Download_Price float not null,
	Upload_Price float not null,
	Channel_Price float not null
)

INSERT INTO [dbo].[Prices] VALUES (5,3,10)

select *
from Prices

--DROP TABLE Prices


select *
from TV_Plan
select *
from Internet_Plan
select *
from Combo_Plan
select *
from Plans
select *
from Clients_Plans_Activated
select *
from Prices
select *
from Clients



BEGIN TRANSACTION;

delete from Clients_Plans_Activated
where Plan_ID in (select p.ID
					from Plans p
					where p.ID=2)--planID
					
delete from Plans
where Combo_Plan_ID in (
	select ID
	from Combo_Plan
	where TV_Plan_ID=1--internetplanID
)

delete from Combo_Plan
where Combo_Plan.TV_Plan_ID=1--internetplanID

DELETE FROM Plans
WHERE id=2;--planID

DELETE FROM TV_Plan
where ID=1;--internetPlanID

COMMIT;
