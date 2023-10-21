--This is the database we will use in our example
use wjkw1_VeterinaryD2

--client
create table Client
	(clientID int not null,
	fname  varchar(32) not null,
	lname  varchar(32) not null,
	phone  varchar(32) not null,
	email  varchar(32) not null,
	clientAddress varchar(64), --changed because address is a datatype
	primary key (clientID)
		)

--treatment
create table Condition
	(condiID int not null,
	title varchar(32),
	descript varchar(max),
	primary key(condiID)
		)

--staff
create table Staff
	(staffID int not null,
	fname varchar(32),
	lname varchar(32),
	staffRole varchar(32), --changed because 'role' is a datatype
	primary key (staffID)	
		)

--specialty
create table Specialty
	(code int not null,
	name varchar (64),
	descript varchar(max),
	primary key (code)	
		)

--animal	
create table Animal
	(animalID int not null,
	category varchar (32),
	breed varchar(32),
	name varchar(32),
	sex varchar(32),
	DoB date,
	clientID int not null,
	primary key (animalID),
	foreign key (clientID) references Client,
	check ( sex in( 'male', 'female'))
		) 

create table Appointment
	(apptID int not null,
	notes varchar(max),
	confirmed varchar(4),
	animalID int not null,
	weight float not null,
	primary key(apptID),
	foreign key(animalID) references Animal,
	check (confirmed in('yes','no')) --assume these are the only two values
		)


--schedule slot
create table ScheduleSlot
	(slotID int not null,
	room varchar(32),
	slotDate date, --changed because 'date' can't be name cause is a datatype
	startTime time,
	endTime time,
	apptID int,
	staffID int,
	primary key(SlotID),
	foreign key(apptID) references Appointment,
	foreign key(staffID) references Staff
	--check room like [1-4] --IMPLEMENT A ROOM CHECK??
		)

--observed 
create table observed
	(condiID int not null,
	apptID int not null,
	primary key(condiID, apptID),
	foreign key(condiID) references Condition,
	foreign key(apptID) references Appointment
		)

create table hasSpecialty
	(staffID int not null,
	code int not null,
	primary key(staffID, code),
	foreign key(staffID) references Staff,
	foreign key(code) references Specialty
		)

--drop table observed
--drop table hasSpecialty
--drop table Animal
--drop table ScheduleSlot
--drop table Appointment
--drop table Condition
--drop table Staff
--drop table Specialty
--drop table Client


--insert into table statements --------------------------------->

--Specialty insert statements --Assume that code is an integer
insert into Specialty values (101, 'Animal Behaviour', 'Specialises in the behaviour of animals and they way that they interact with each other, humans and also reasons why animals do certain things.')
insert into Specialty values (102, 'Emergency and Critical Care', 'Specialises in the diagnosis and managment of life-threatening conditions requiring organ support and invasive monitoring.')
insert into Specialty values (103, 'Nutritionalist', 'Specialises in animal nutrition and can help with animals recovery before and after operations etc.')
insert into Specialty values (104, 'Parasitology', 'Specialises in animal parasites, especially the relationship between parasite and animal hosts.')
insert into Specialty values (105, 'Radiology', 'Specialises in analysing and diagnosing animals using a variety of imaging technology, such as x-ray radiography, ultrasound etc.')
insert into Specialty values (106, 'Surgery', 'Specialises in the operations that involve invasive methods, broadly there are three categories which include: orthopaedics, soft tissue and neurosurgery.')

--update Specialty
--set descript = 'Specialises in the operations that involve invasive methods, broadly there are three categories which include: orthopaedics, soft tissue and neurosurgery.'
--where code = 106

--Treatment insert statements
insert into Condition values (400, 'Stomach foreign object', 'An object that does not belong with the animal that has been eaten and is inside animals stomach.')
insert into Condition values (401, 'Broken leg', 'The animal has broken their leg, can be either a hairline fracture or worse.')
insert into Condition values (402, 'Laryngeal paralysis', 'The animals larynx does not open and closed properly, making it difficult to breathe or eat.')
insert into Condition values (403, 'Intestinal foreign object', 'An animals gastrointestinal tract is unable to allow a foreign object to readily pass through')
insert into Condition values (404, 'Intervertebral disc disease', 'A slipped disc in the animals spine')
insert into Condition values (405, 'Flea infestation', 'Animal has become host to a large amount of parasitic fleas, ')


 

select * 
from Specialty

select *
from Condition

select * from ScheduleSlot

select * from Client

Select * from Staff