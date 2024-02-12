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

select *
from Internet_Plan

--DROP TABLE Internet_Plan

---------TV_PLAN
create table TV_Plan 
(
	ID int IDENTITY(1,1) primary key,
	Channel_Number int not null
)

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
from clients


