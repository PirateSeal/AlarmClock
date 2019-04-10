-- Create the table in the specified schema
CREATE TABLE spi.tAccounts
(
    AccountId      INT           IDENTITY(0,1),
    -- primary key column
    Pseudo         NVARCHAR(255) COLLATE Latin1_General_CI_AI NOT NULL,
    HashedPassword NVARCHAR(255),

    CONSTRAINT PK_AccountId PRIMARY KEY(AccountId),
    CONSTRAINT UK_tAccountsId_Pseudo UNIQUE(Pseudo)
);

-- Insert rows into table 'spi.tAccounts'
INSERT INTO spi.tAccounts
    ( -- columns to insert data into
    Pseudo, HashedPassword
    )
VALUES
    ( -- first row: values for the columns in the list above
        LEFT(CONVERT(NVARCHAR(36),newid()),32), LEFT(CONVERT(NVARCHAR(36),newid()),32)
);

GO

-- Create the table in the specified schema
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
    ( -- first row: values for the columns in the list above
        'Patient'
);
GO

-- Create the table in the specified schema
CREATE TABLE spi.tUsers
(
    UserId    INT           IDENTITY(0,1),
    -- primary key column
    AccountId INT           IDENTITY(0,1),
    FirstName NVARCHAR(255)COLLATE Latin1_General_CI_AI NOT NULL,
    LastName  NVARCHAR(255) COLLATE Latin1_General_CI_AI NOT NULL,
    BirthDate DATETIME2     NOT NULL,
    UserType  INT,

    CONSTRAINT PK_UserId PRIMARY KEY(UserId),
    CONSTRAINT FK_tUsers_tAccounts FOREIGN KEY(AccountId) REFERENCES spi.tAccounts(AccountId),
    CONSTRAINT FK_tUsers_tUserTypes FOREIGN KEY(UserType) REFERENCES spi.tUserTypes(UserTypeId),
    CONSTRAINT UK_tUsers_FirstName_LastName UNIQUE(FirstName, LastName),
    CONSTRAINT CK_tUsers_FirstName CHECK(FirstName <> N''),
    CONSTRAINT CK_tUsers_LastName CHECK(LastName <> N'')
);

-- Insert rows into table 'spi.tUsers'
INSERT INTO spi.tUsers
    ( -- columns to insert data into
    FirstName, LastName, BirthDate, AccountId
    )
VALUES
    ( -- first row: values for the columns in the list above
        LEFT(CONVERT(NVARCHAR(36), newid()), 32), LEFT(CONVERT(NVARCHAR(36), newid()), 32), '00010101', 0
);
GO
