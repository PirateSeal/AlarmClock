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

-- Insert rows into table 'spi.tUsers'
INSERT INTO spi.tUsers
    ( -- columns to insert data into
    [Pseudo], [Email], [HashedPassword],[FirstName]
    ,[LastName],[BirthDate],[UserType])
VALUES
    ( -- first row: values for the columns in the list above
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        'dummy.email@mail.com',
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        '00010101',
        0
    );
GO