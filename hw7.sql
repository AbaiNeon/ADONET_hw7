create database loginDB

use loginDB

CREATE TABLE tblUsers
(
    [User_id] INT primary key identity,
    NikName VARCHAR(50) not null,
    [Password] VARCHAR(50) not null,
	[Address] VARCHAR(50) not null,
	Tel VARCHAR(50) not null,
	IsAdmin bit not null
)

insert into tblUsers
values
('admin', '1', 'Tom str', '124578', 1),
('User2', '2', 'Ben str', '986532', 0),
('User3', '3', 'Tim str', '175398', 0)

select * from tblUsers
drop table tblUsers