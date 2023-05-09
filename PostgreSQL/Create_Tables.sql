
CREATE TABLE Client (
    Id SERIAL PRIMARY KEY,
    ContactName VARCHAR(30),
    Tlf VARCHAR(20) UNIQUE,											-- ask: is it good to have too many constraints?
    Address TEXT UNIQUE,	
    FeeMultiplier FLOAT											-- ask: less strict database -- better?
);

CREATE TABLE Category (
    Id SERIAL PRIMARY KEY,
    CategoryName VARCHAR(11) NOT NULL,
    OralFee FLOAT,
    WrittenFee FLOAT,
    PhoneFee FLOAT,
    TransportCostFee FLOAT,
    TransportTimeFee FLOAT
);

CREATE TABLE Translator (
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    Age INT DEFAULT 18 CHECK (Age >= 18 AND Age <= 70),
    CityAddress TEXT NOT NULL,
    StreetNrAddress TEXT NOT NULL,
    Email VARCHAR(30) UNIQUE,
    Tlf VARCHAR(20) UNIQUE,
    Education VARCHAR(40) NOT NULL
);

CREATE TABLE Language (
    Id SERIAL PRIMARY KEY,
    NameOfLang VARCHAR(20) NOT NULL
);

CREATE TABLE TranslatorCompetence (
    Id SERIAL PRIMARY KEY,
    TranslatorId INT REFERENCES Translators(Id),
    LanguagesId INT REFERENCES Languages(Id),
    CategoryId INT REFERENCES Categories(Id)
);

CREATE TABLE Task (
    Id SERIAL PRIMARY KEY,
    DateOfTask DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Urgent BOOLEAN,													-- both implemented in C#
    Difficult BOOLEAN,
    TranslatorCompetenceID INT REFERENCES TranslatorCompetence(Id),	-- references concrete translator and her language used 
    ClientId INT REFERENCES Client(Id) ON DELETE CASCADE			-- 'has a'-relationship between task and client
);

CREATE TABLE Review (
    Id SERIAL PRIMARY KEY,
    DateOfReview DATE NOT NULL,
    ReviewBody TEXT,
    Stars INT DEFAULT 0 CHECK (Stars >= 0 AND Stars <= 5),
    TaskId INT REFERENCES Task(Id) ON DELETE CASCADE
);


CREATE TABLE TranslatorEmployment (
    Id SERIAL PRIMARY KEY,
    EmploymentDate DATE NOT NULL,   -- min employmentDate indtil i dag (fra 1.ansættelse til i dag)
    DismissalDate DATE,		        -- max dissmissalDate		(if NOT NULL then the translator must be employed and not be dissmissed)						
    Position VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(100) NOT NULL,
    TranslatorID INT REFERENCES Translators(Id) ON DELETE CASCADE       -- group by Translator_ID
);

/* Statement for at hive experience from TRanslatorEmployment table:
1) aggregate function: AVG SUm MIN MAX group by Translator_ID and group by Translator_ID
2) DATEDIFF (dismissalD - employmentDate, then find the sum of differences (fordi ingen overlappende perioder, men i real life er det mere kompliceret fordi man kan arbjde flere firma på samme tid)

Constraint: translators kan kun arbejde i et firma ad gangen, men in real life kan hun være ansat flere steder samtidigt

/*
drop TranslatorReviews og make statements that calculate the average score af alle reviewed tasks for en translator
TranslatorScore == average of all Translator's tasks.
*/

/* join 4 tabeller for at vise en translators average review 




