Create table Person (
 Id int IDENTITY(1,1),
  LastName varchar(255) NOT NULL,
  FirstName varchar(255) NOT NULL,
  Address varchar(255),
  City varchar(255),
  PRIMARY KEY (Id)
)


ALTER DATABASE NotificationDb SET ENABLE_BROKER  


update Person
set  LastName = '25'
where Id = 2