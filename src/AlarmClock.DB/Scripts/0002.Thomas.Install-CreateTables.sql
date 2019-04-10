-- Create a new table called 'tUserTypes' in schema 'spi'
CREATE TABLE spi.tUserTypes
(
    UserTypeId INT         IDENTITY(0,1),
    -- primary key column
    UserType   VARCHAR(15) COLLATE Latin1_General_CI_AI NOT NULL,

    CONSTRAINT PK_UserTypeId PRIMARY KEY (UserTypeId),

    CONSTRAINT CK_tUserTypes_UserType CHECK(UserType <> N'')
);

-- Insert rows into table 'spi.tUserTypes'
INSERT INTO spi.tUserTypes
    ( -- columns to insert data into
    UserType
    )
VALUES
    -- first row: values for the columns in the list above
    ('Patient'),
    ('Doctor'),
    ('Administrator')
;
GO

-- Create a new table called 'tUsers' in schema 'spi'
CREATE TABLE spi.tUsers
(
    UserId         INT           IDENTITY(0,1),
    -- primary key column
    Pseudo         NVARCHAR(255) COLLATE Latin1_General_CI_AI NOT NULL,
    Email          NVARCHAR(35)  NOT NULL,
    HashedPassword NVARCHAR(255) NOT NULL,
    FirstName      NVARCHAR(255) COLLATE Latin1_General_CI_AI NOT NULL,
    LastName       NVARCHAR(255) COLLATE Latin1_General_CI_AI NOT NULL,
    BirthDate      DATETIME2     NOT NULL,
    UserType       INT,

    CONSTRAINT PK_UserId PRIMARY KEY(UserId),

    CONSTRAINT FK_tUsers_tUserTypes 
        FOREIGN KEY(UserType) 
        REFERENCES spi.tUserTypes(UserTypeId),

    CONSTRAINT UK_tUsers_Pseudo UNIQUE(Pseudo),
    CONSTRAINT UK_tUsers_Email UNIQUE(Email),
    CONSTRAINT UK_tUsers_FirstName_LastName UNIQUE(FirstName, LastName),

    CONSTRAINT CK_tUsers_Pseudo CHECK(Pseudo <> N''),
    CONSTRAINT CK_tUsers_Email CHECK(Email <> N''),
    CONSTRAINT CK_tUsers_HashedPassword CHECK(HashedPassword <> N''),
    CONSTRAINT CK_tUsers_FirstName CHECK(FirstName <> N''),
    CONSTRAINT CK_tUsers_LastName CHECK(LastName <> N'')
);

-- Create a new table called 'tRegisteredClocks' in schema 'spi'
CREATE TABLE spi.tRegisteredClocks
(
    RegisteredClockId INT           NOT NULL IDENTITY(0,1),
    -- primary key column
    [Name]            NVARCHAR(255) NOT NULL,
    [GUID]            NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_RegisteredClockId PRIMARY KEY(RegisteredClockId),

    CONSTRAINT UK_tRegisteredClocks_Name UNIQUE([Name]),
    CONSTRAINT UK_tRegisteredClocks_GUID UNIQUE([GUID])
);
GO

-- Create a new table called 'tComponents' in schema 'spi'
CREATE TABLE spi.tComponents
(
    ComponentId INT           NOT NULL ,
    -- primary key column
    [Name]      NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_ComponentId PRIMARY KEY(ComponentId),

    CONSTRAINT UK_tComponents_Name UNIQUE([Name])
);
GO

-- Insert rows into table 'spi.tComponents'
INSERT INTO spi.tComponents
    ( -- columns to insert data into
    [Name]
    )
VALUES
    -- first row: values for the columns in the list above
    ('Microphone'),
    ('Speaker'),
    ('Screen'),
    ('Tactile Screen')
GO

-- Create a new table called 'tClockComponents' in schema 'spi'
CREATE TABLE spi.tClockComponents
(
    ClockComponentId INT NOT NULL IDENTITY(0,1),
    -- primary key column
    ClockId          INT NOT NULL,
    ComponentId      INT NOT NULL,

    CONSTRAINT PK_ClockComponentId PRIMARY KEY(ClockComponentId),

    CONSTRAINT FK_tClockComponents_tRegisteredClocks
        FOREIGN KEY(ClockId)
        REFERENCES spi.tRegisteredClocks(RegisteredClockId),
    CONSTRAINT FK_tClockComponents_tComponents
        FOREIGN KEY(ComponentId)
        REFERENCES spi.tComponents (ComponentId)
);
GO