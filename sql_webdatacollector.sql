CREATE database db_users;
USE db_users;

create table Role(
					Id_Role INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
					Name VARCHAR(100) NULL
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table User(
                      Id_User BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      UserName VARCHAR(100) NOT NULL,
                      Password VARCHAR(100) NOT NULL,
                      Role_id INT default null,
                      CONSTRAINT FK_User_Role FOREIGN KEY (Role_id) REFERENCES Role (Id_Role),
                      Family_name VARCHAR(256) null,
                      Name_ VARCHAR(256) null,
                      Patronymic_name VARCHAR(256) NULL,
                      Date_birth date NULL,
                      Telephone VARCHAR(12) null
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table City(
                      Id_City INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      Name VARCHAR(256) NULL                      
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table FieldActivity(
                      Id_FieldActivity INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      Name VARCHAR(256) NULL                      
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table District(
                      Id_District INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      Name VARCHAR(256) NULL                      
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Polling_station(
                      Id_Polling_station INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      Name VARCHAR(256) NULL                      
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table Friend(
                      Id_Friend BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                      Family_name VARCHAR(256) NULL,
                      Name_ VARCHAR(256) NULL,
                      Patronymic_name VARCHAR(256) NULL,
                      Date_birth date,
                      City_id INT default null,
                      CONSTRAINT FK_Friend_City FOREIGN KEY (City_id) REFERENCES City (Id_City)
                      ON delete set null on update restrict,
                      Street VARCHAR(256) null,
                      House VARCHAR(10) null,
                      Apartment VARCHAR(10) null,
                      Telephone VARCHAR(12) null,                      
                      District_id INT default null,
                      CONSTRAINT FK_Friend_District FOREIGN KEY (District_id) REFERENCES District (Id_District)
                      ON delete set null on update restrict,
                      Polling_station_id INT default null,
                      CONSTRAINT FK_Friend_Polling_station FOREIGN KEY (Polling_station_id) REFERENCES Polling_station (Id_Polling_station)
                      ON delete set null on update restrict,
                      Organization VARCHAR(256) null,
                      FieldActivity_id INT default null,
                      CONSTRAINT FK_Friend_FieldActivity FOREIGN KEY (FieldActivity_id) REFERENCES FieldActivity (Id_FieldActivity)
                      ON delete set null on update restrict,
                      Phone_number_responsible VARCHAR(12) null,
                      Date_registration_site date null,
                      Voting_date date null,
					  Voter TINYINT NULL DEFAULT 0,
					  Adress VARCHAR(4500) null,
                      Description VARCHAR(256) null,
					  User_id BIGINT default null,
                      CONSTRAINT FK_Friend_User FOREIGN KEY (User_id) REFERENCES User (Id_User)
                      ON delete set null on update restrict
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

ALTER TABLE `db_users`.`friend` 
ADD COLUMN `Voter` TINYINT NULL DEFAULT 0 AFTER `Voting_date`;

ALTER TABLE `db_users`.`friend` 
ADD COLUMN `Adress` VARCHAR(500) NULL DEFAULT NULL AFTER `User_id`;



INSERT INTO Role (Name) VALUES ('admin');
INSERT INTO Role (Name) VALUES ('user');

INSERT INTO User (UserName, Password, Role_id, Family_name, Name_, Patronymic_name, Date_birth, Telephone) VALUES ('vldmr@ya.ru','qwerty321','1',
                     'Луценко','Владимир','Serg','1987.01.01','+79292822101');
INSERT INTO User (UserName, Password, Role_id, Family_name, Name_, Patronymic_name, Date_birth, Telephone) VALUES ('alex@ya.ru','qwerty654','1',
                     'Синцев','Алексей','Алексеевич','1987.01.01','+00000000000');
INSERT INTO User (UserName, Password, Role_id, Family_name, Name_, Patronymic_name, Date_birth, Telephone) VALUES ('poligraf@ya.ru','2','2',
                     'Полиграф','Полиграфович','Шариков','1987.01.01','+00000000000');

INSERT INTO District (Name) VALUES ('Северный');
INSERT INTO District (Name) VALUES ('Южный');
                     
INSERT INTO City (Name) VALUES ('Оренбург');
INSERT INTO City (Name) VALUES ('Ростоши');
INSERT INTO City (Name) VALUES ('Кушкуль');
                     
INSERT INTO FieldActivity (Name) VALUES ('Промышленность');
INSERT INTO FieldActivity (Name) VALUES ('Образование');
INSERT INTO FieldActivity (Name) VALUES ('Торговля');

INSERT INTO Polling_station (Name) VALUES ('1');
INSERT INTO Polling_station (Name) VALUES ('2');
INSERT INTO Polling_station (Name) VALUES ('3');

INSERT INTO Friend (Family_name, Name_, Patronymic_name, Date_birth, City_id, Street, House,Apartment, Telephone, Polling_station_id, District_id, Organization, FieldActivity_id, Phone_number_responsible, Date_registration_site, Voting_date,  Description,  User_id) VALUES
				('Vladimir','Volodya','Serg','1995.01.01',1,'Культурная','8','','+79292822102',1,1,'ПО СТрела',1,'+79225353971','2021.04.01','2021.04.20','',1);
INSERT INTO Friend (Family_name, Name_, Patronymic_name, Date_birth, City_id, Street, House,Apartment, Telephone, Polling_station_id, District_id, Organization, FieldActivity_id, Phone_number_responsible, Date_registration_site, Voting_date,  Description,  User_id) VALUES
				('Иванов','Иван','Иванович','1991.01.01',2,'Советская','30','5','+79292822102',2,2,'ОГУ',2,'+79225353971','2021.04.01','2021.04.20','',1);
INSERT INTO Friend (Family_name, Name_, Patronymic_name, Date_birth, City_id, Street, House,Apartment, Telephone, Polling_station_id, District_id, Organization, FieldActivity_id, Phone_number_responsible, Date_registration_site, Voting_date,  Description,  User_id) VALUES
				('Петров','Петр','Петрович','1991.01.01',1,'Советская','30','5','+79292822102',3,2,'АО Ромашка',3,'+79225353971','2021.04.01','2021.04.20','',2);
                
Drop table friend;
Drop table district;
Drop table fieldactivity;
Drop table polling_station;
Drop table city;
Drop table user;
Drop table role;