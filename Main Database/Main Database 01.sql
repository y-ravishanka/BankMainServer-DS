
create database bankmain

use bankmain

create table account
(
	number int not null,
	nic varchar(15) not null,
	balance float not null,
	active varchar(5) default 'true',
	branchid int not null,
	createby int not null,
	primary key (number)
)

select * from account
delete account
drop table account

insert into account (number,nic,balance,branchid,createby) values
(20156,'5628973v',100,5,124),
(20168,'5626813v',2000,5,124)

create table branch
(
	id int identity(1,1),
	name varchar(100) not null,
	saddress varchar(200) not null,
	city varchar(50) not null,
	distric varchar(50) not null,
	province varchar(50) not null,
	zip varchar(10) not null,
	phone1 varchar(12) not null,
	phone2 varchar(12) not null,
	email varchar(100) not null,
	managerid int not null,
	primary key (id)
)

select * from branch
delete branch
drop table branch

create table employee
(
	id int identity(1,1),
	nic varchar(15)  not null,
	fname varchar(100)  not null,
	lname varchar(200)  not null,
	dob varchar(8)  not null,
	saddress varchar(200)  not null,
	city varchar(50)  not null,
	distric varchar(50)  not null,
	province varchar(50)  not null,
	zip varchar(10)  not null,
	phone1 varchar(12)  not null,
	phone2 varchar(12)  null,
	email varchar(100)  not null,
	branchid int not null,
	primary key (nic)
)

select * from employee
delete employee
drop table employee

create table fullstatus
(
	id int identity(1,1),
	date varchar(20) not null,
	deposits int default 0,
	damount float default 0,
	withdraws int default 0,
	wamount float default 0,
	balance float default 0,
	newaccounts int default 0,
	primary key (date)
)

select * from fullstatus
delete fullstatus
drop table fullstatus

create table tmp_activitylog
(
	id int not null,
	logintime datetime not null,
	logouttime datetime null,
	primary key (id)
)

select * from tmp_activitylog
delete tmp_activitylog
drop table tmp_activitylog

create table activitylog
(
	id int not null,
	logintime datetime not null,
	logouttime datetime null,
	primary key (id,logintime)
)

select * from activitylog where id = '1321415'
delete activitylog
drop table activitylog

exec insert_logintime @id = 1321415
exec insert_logouttime @id = 1321415

create table login_details
(
	id int not null,
	nic varchar(13) not null,
	password varchar(16) null,   /* no need to enter a value system with auto fill it */
	posision varchar(30) not null,
	active varchar(10) default 'true',  /* no need to enter a value */
	resetpass int default 0,
	primary key (nic)
)

select * from login_details
delete login_details
drop table login_details

create table transactions
(
	id varchar(20) not null,
	date varchar(10) not null,
	type varchar(10) not null,
	account int not null,
	amount float not null,
	depositor varchar(15) null,
	primary key (id)
)

select * from transactions
delete transactions
drop table transactions


create table branchbaseurl
(
	id int not null,
	city varchar(100) not null,
	baseurl varchar(100) not null
	primary key (id)
)

select * from branchbaseurl
delete branchbaseurl
drop table branchbaseurl

/*
select GETDATE()

create table timetest
(
	time varchar(30),
	date datetime null
)

select * from timetest
delete timetest
drop table timetest

insert into timetest values (GETDATE(),GETDATE())
*/