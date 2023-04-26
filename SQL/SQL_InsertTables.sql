use Translation_Agency;


INSERT INTO Categories (CategoryName, OralFee, WrittenFee, PhoneFee, TransportCostFee, TransportTimeFee)
VALUES ('Category 1', 410, 4.5, 400, 205, 3.13),
       ('Category 2', 290, 3.2, 250, 145, 3.13),
       ('Category 3', 110, 2, 100, 55, 3.13);



INSERT INTO Translators (FirstName, LastName, Age, CityAddress, StreetNrAddress, Email, Tlf, Education)
VALUES
( 'Sarah', 'Lee', 27, 'Chicago', '789 Maple St.', 'sarah.lee@example.com', '555-3456', 'Bachelor of Arts in Translation'),
( 'Luis', 'Gonzalez', 29, 'Bogota', '456 Oak St.', 'luis.gonzalez@example.com', '555-6789', 'Master of Arts in Translation'),
( 'Elena', 'Vasilieva', 40, 'St. Petersburg', '123 Cedar St.', 'elena.vasilieva@example.com', '555-0123', 'PhD in Translation Studies'),
( 'David', 'Kim', 25, 'Seoul', '789 Main St.', 'david.kim@example.com', '555-4567', 'Secondary School'),
( 'Sofia', 'Gomez', 32, 'Madrid', '456 Pine St.', 'sofia.gomez@example.com', '555-8901', 'Master of Arts in Translation'),
( 'Masato', 'Yamamoto', 48, 'Osaka', '123 Elm St.', 'masato.yamamoto@example.com', '555-2345', 'PhD in Translation Studies'),
( 'Emily', 'Chen', 23, 'San Francisco', '789 Oak St.', 'emily.chen@example.com', '555-6799', 'Bachelor of Arts in Linguistics'),
( 'Luisa', 'Rodriguez', 35, 'Santiago', '456 Maple St.', 'luisa.rodriguez@example.com', '555-2123', 'Master of Science in Translation'),
( 'Dmitry', 'Petrov', 51, 'Moscow', '123 Cedar St.', 'dmitry.petrov@example.com', '555-4537', 'PhD in Translation Studies'),
( 'Jasmine', 'Wong', 29, 'Hong Kong', '789 Pine St.', 'jasmine.wong@example.com', '555-8701', 'Bachelor of Arts in Translation'),
( 'Roberto', 'Ortega', 40, 'Mexico City', '456 Oak St.', 'roberto.ortega@example.com', '552-2345', 'Master of Arts in Translation'),
( 'Katarina', 'Ivanova', 36, 'Sofia', '123 Maple St.', 'katarina.ivanova@example.com', '555-6019', 'PhD in Translation Studies'),
( 'Thomas', 'Smith', 31, 'New York', '789 Main St.', 'thomas.smith@example.com', '554-0123', 'Secondary School'),
( 'Ana', 'Fernandez', 27, 'Buenos Aires', '456 Cedar St.', 'ana.fernandez@example.com', '455-4567', 'Master of Arts in Translation');


INSERT INTO Languages (NameOfLang)
VALUES ('English'),
       ('Spanish'),
       ('French'),
       ('German'),
       ('Mandarin'),
       ('Arabic'),
       ('Portuguese'),
       ('Russian'),
       ('Italian'),
       ('Dutch'),
       ('Swedish'),
       ('Norwegian'),
       ('Finnish'),
       ('Danish'),
       ('Greek'),
       ('Turkish'),
       ('Japanese'),
       ('Korean'),
       ('Thai'),
       ('Vietnamese'),
       ('Hindi'),
       ('Bengali'),
       ('Urdu'),
       ('Punjabi'),
       ('Persian'),
       ('Indonesian'),
       ('Malay'),
       ('Filipino'),
       ('Swahili'),
       ('Czech'),
       ('Polish');


INSERT INTO TranslatorLanguagesJunction (TranslatorId, LanguagesId, CategoryId)
VALUES
    (11, 1, 1),
    (11, 2, 2),
    (11, 3, 3),
    (12, 2, 1),
    (12, 3, 2),
    (12, 4, 3),
    (13, 3, 1),
    (13, 4, 2),
    (13, 5, 3),
    (14, 10, 1),
    (15, 31, 1),
    (15, 30, 2),
    (16, 28, 1),
    (16, 1, 2),
    (16, 14, 3),
    (16, 12, 3),
    (17, 6, 1),
    (17, 25, 2),
    (18, 20, 1),
    (19, 1, 1),
    (19, 4, 2),
    (19, 3, 3),
    (20, 10, 1),
    (20, 11, 2),
    (20, 13, 3),
    (20, 15, 3),
    (21, 5, 1),
    (22, 27, 1),
    (22, 1, 2),
    (22, 21, 3),
    (22, 18, 3),
    (23, 10, 1),
    (23, 8, 2),
    (23, 12, 3),
    (23, 24, 3),
    (24, 1, 1),
    (24, 10, 2),
    (24, 14, 3);

    

INSERT INTO ClientMultiplierClass (NameClient, FeeMultiplier)
VALUES
('Police', 1.0),
('Court Copenhagen', 1.2),
('Court Helsingør', 1.3),
('Court Århus', 1.4),
('Court Roskilde', 1.3),
('Court Hellerup', 1.5),
('Court Ålborg', 1.3),
('Court Viborg', 1.1);


-- Insert Immigration Service
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Immigration Service', 2, '12345677', '123 Main St');

-- Insert Home Travel Agency
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Home Travel Agency', 2, '87654321', '456 Elm St');

-- Insert private persons
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Emilie Spildsboel Hansen', 1, '97111111', '34 Frederiksborggade');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Abdul Farati', 1, '33222222', '321 Oak St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Bob Johnson', 1, '45333333', '555 Pine St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Thomas Akhøj Holtze', 1, '28444444', '443 Cedar St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Lea Holtze', 1, '78555555', '779 Walnut St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Lars Akhøj', 1, '50666666', '87 Oak St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Anne-Mette Ibsen', 1, '40777777', '222 Elm St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Brian Jensen', 1, '88888828', '1 Maple St');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Helena Nielsen', 1, '99999994', '99 Pine St');


-- Insert police stations
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Aalborg', 1, '12312311', 'Kjellerups Torv 5, 9000 Aalbor');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Aarhus', 1, '12341236', 'Værkmestergade 1, 8000 Aarhus');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Copenhagen', 1, '12341235', 'København');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Frederiksberg', 1, '12312322', 'Frederiksberg Allé 20, 1820 Fr');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Herning', 1, '12341239', 'Østergade 8, 7401 Herning');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Holstebro', 1, '12341243', 'Nørregade 6, 7500 Holstebro');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Kolding', 1, '12312313', 'Østre Havnevej 20, 6000 Koldin');
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES ('Police Station Odense', 1, '12341238', 'Kochsgade 33, 5000 Odense C');


-- insert courts in Denmark
INSERT INTO Client (ContactName, ClientMultiplier, Tlf, Address)
VALUES
('Copenhagen Court', 2, '12345676', 'Tingshuset, Nytorv 1, 1450 Køb'),
('Hillerød Court', 3, '23456789', 'Domhuset, Fred 28, 3400 Hiller'),
('Helsingør Court', 6, '34567890', 'Slotsvænget 2, 3000 Helsingør'),
('Roskilde Court', 5, '45678901', 'Domhuset, Algade 38, 4000 Rosk'),
('Århus Court', 4, '56789012', 'Domhuset, Vester Allé 10, Aarh'),
('Ålborg Court', 6, '69890123', 'Retten i Aalborg, Strandvejen'),
('Landsbyret', 2, '78931234', 'Halmtorvet 12, 3000 København');


INSERT INTO Tasks (DateOfTask, StartTime, EndTime, TranslationId, ClientId, Urgent, Difficult)
VALUES 
('2000-03-18', '09:43:00', '15:12:00', 22, 32, 1, 0),
('2015-07-21', '07:16:00', '11:33:00', 18, 35, 1, 0),
('2006-09-11', '02:09:00', '05:31:00', 13, 38, 0, 1),
('2008-10-02', '08:37:00', '12:21:00', 29, 41, 0, 0),
('2013-12-19', '04:45:00', '11:18:00', 4, 44, 1, 1),
('2019-06-07', '00:25:00', '04:01:00', 17, 47, 0, 0),
('2003-10-26', '04:47:00', '09:13:00', 3, 82, 1, 1),
('2011-05-15', '01:58:00', '08:39:00', 20, 85, 1, 0),
('2005-12-09', '06:35:00', '12:45:00', 2, 88, 0, 1),
('2022-09-24', '01:10:00', '07:53:00', 10, 32, 1, 0),
('2017-11-01', '04:34:00', '10:09:00', 30, 35, 0, 0),
('2009-08-08', '03:25:00', '09:37:00', 28, 38, 1, 0);



