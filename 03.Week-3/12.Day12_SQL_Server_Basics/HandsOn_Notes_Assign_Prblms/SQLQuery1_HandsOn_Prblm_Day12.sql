----SQL CONSTRAINTS BASED-----
CREATE DATABASE EventDb;

USE EventDb;

CREATE TABLE UserInfo (
    EmailId VARCHAR(50) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL CHECK(LEN(UserName) between 1 and 50),
	Role VARCHAR(20) NOT NULL CHECK(Role IN ('Admin', 'Participant')),
	Password VARCHAR(20) NOT NULL CHECK(LEN(Password) BETWEEN 6 AND 20)
	);
	
CREATE TABLE EventDetails (
      EventId INT PRIMARY KEY,
	  EventName VARCHAR(50) not null check (len(EventName) between 1 and 50),
	  EventCategory varchar(50) not null check(len(EventCategory) between 1 and 50),
	  EventDate datetime not null,
	  Description varchar(500) null,
	  Status varchar(20) check (Status in ('Active', 'In-Active'))
	  );


create table SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) not null check (len(SpeakerName) BETWEEN 1 AND 50)
);


CREATE TABLE SessionInfo (
      SessionId int primary key,
	  EventId int not null foreign key(EventId) REFERENCES EventDetails(EventId),
	  SessionTitle varchar(50) not null check(len(SessionTitle) between 1 and 50),
	  SpeakerId int not null foreign key(SpeakerId) references SpeakersDetails(SpeakerId),
	  Description varchar(500) null,
	  SessionStart datetime not null,
	  SessionEnd datetime not null,
	  SessionUrl varchar(200),
	  );
	
CREATE TABLE ParticipantEventDetails (
    Id int primary key,
	ParticipantEmailId varchar(50) not null  FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
	EventId INT not null FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
	SessionID int not null FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId),
	IsAttended bit  not null check(IsAttended in(0,1))
	);


drop TABLE ParticipantEventDetails;


select * from EventDetails;
select * from ParticipantEventDetails;
select * from SessionInfo;
select * from SpeakersDetails;
select * from UserInfo
--desc table EventDetails--;
--- DROP TABLE SessionInfo;- -

----table 1 Data--
INSERT INTO UserInfo VALUES
('admin@gmail.com', 'AdminUser', 'Admin', 'admin123'),
('vinay@gmail.com', 'Vinay', 'Participant', 'vinay123'),
('vini@gmail.com', 'Vinaykumar', 'Admin','vini123');

---table 2 Data--
INSERT into EventDetails Values 
(1,'AI Summit','AI Technology','2026-03-25','Annual Tech Event', 'Active'),
(2,'Tech Summit','Technology','2026-04-12','Year Wise Tech Event', 'In-Active');


---table 3 dtaa----
insert into SpeakersDetails values
(101, 'Shiva Kumar'),
(102,'Rama');


--- table 4 data--
INSERT INTO SessionInfo VALUES 
(1001, 1,'AI Future', 101, 'AI Discussion','2026-03-25 09:00:00','2026-03-25 12:00:00','https://Zoomlink.com/session1');
INSERT INTO SessionInfo VALUES 
(1002, 2,'AI Future', 102, 'ML Discussion','2026-04-12 10:00:00','2026-04-12 11:00:00','https://Zoomlink.com/session2');


DELETE FROM SessionInfo
WHERE SessionId = 1002;

-------------------------------------------
INSERT INTO ParticipantEventDetails VALUES(1, 'vinay@gmail.com', 1, 1001, 1);

INSERT INTO ParticipantEventDetails VALUES(2, 'admin@gmail.com', 2, 1002, 0);
