CREATE TABLE ClientMultiplierClass (
    Id SERIAL PRIMARY KEY,
    NameClient VARCHAR(30),
    FeeMultiplier FLOAT
);

CREATE TABLE Client (
    Id SERIAL PRIMARY KEY,
    ContactName VARCHAR(30),
    ClientMultiplier INT REFERENCES ClientMultiplierClass(Id),
    Tlf VARCHAR(20) UNIQUE,											-- ask: is it good to have too many constraints?
    Address TEXT UNIQUE												-- ask: less strict database -- better?
);

CREATE TABLE Categories (
    Id SERIAL PRIMARY KEY,
    CategoryName VARCHAR(11) NOT NULL,
    OralFee FLOAT,
    WrittenFee FLOAT,
    PhoneFee FLOAT,
    TransportCostFee FLOAT,
    TransportTimeFee FLOAT
);

CREATE TABLE Translators (
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    DateOfEmployment DATE NOT NULL,
    Age INT DEFAULT 18 CHECK (Age >= 18 AND Age <= 70),
    CityAddress TEXT NOT NULL,
    StreetNrAddress TEXT NOT NULL,
    Email VARCHAR(30) UNIQUE,
    Tlf VARCHAR(20) UNIQUE,
    Education VARCHAR(40) NOT NULL,
    Experience FLOAT NOT NULL										-- TODO total sum
);

CREATE TABLE Languages (
    Id SERIAL PRIMARY KEY,
    NameOfLang VARCHAR(20) NOT NULL
);

CREATE TABLE TranslatorLanguagesJunction (
    Id SERIAL PRIMARY KEY,
    TranslatorId INT REFERENCES Translators(Id),
    LanguagesId INT REFERENCES Languages(Id),
    CategoryId INT REFERENCES Categories(Id)
);

CREATE TABLE Reviews (
    Id SERIAL PRIMARY KEY,
    DateOfReview DATE NOT NULL,
    ReviewBody TEXT,
    Stars INT DEFAULT 0 CHECK (Stars >= 0 AND Stars <= 5)
);

CREATE TABLE Tasks (
    Id SERIAL PRIMARY KEY,
    DateOfTask DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Urgent BOOLEAN,													-- both implemented in C#
    Difficult BOOLEAN,
    TranslationID INT REFERENCES TranslatorLanguagesJunction(Id),	-- references concrete translator and her language used 
    ClientId INT REFERENCES Client(Id) ON DELETE CASCADE,			-- 'has a'-relationship between task and client
    ReviewId INT REFERENCES Reviews(Id) ON DELETE CASCADE
);

CREATE TABLE Experience (
    Id SERIAL PRIMARY KEY,
    EmploymentDate DATE NOT NULL,
    DismissalDate TIME NOT NULL,
    TotalTimeAtCompany FLOAT,										-- TODO difference 
    Position VARCHAR(100) NOT NULL,
    CompanyName VARCHAR(100) NOT NULL,
    TranslatorID INT REFERENCES Translators(Id) ON DELETE CASCADE
);



