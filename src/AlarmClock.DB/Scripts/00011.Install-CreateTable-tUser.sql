/*
 * File: 0002.Install-CreateTable-tUser.sql                                    *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:32 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tUser' in schema 'spi'
CREATE TABLE spi.tUser
(
    UserId         INT            IDENTITY(0,1) NOT NULL,
    -- primary key column
    Pseudo         NVARCHAR(255)  COLLATE Latin1_General_CI_AI NOT NULL,
    Email          NVARCHAR(35)   NOT NULL,
    HashedPassword VARBINARY(128) NOT NULL,
    FirstName      NVARCHAR(255)  COLLATE Latin1_General_CI_AI NOT NULL,
    LastName       NVARCHAR(255)  COLLATE Latin1_General_CI_AI NOT NULL,
    BirthDate      DATETIME2      NOT NULL,
    UserType       CHAR           NOT NULL DEFAULT 'U',

    CONSTRAINT PK_UserId PRIMARY KEY(UserId),

    CONSTRAINT UK_tUser_Pseudo UNIQUE(Pseudo),
    CONSTRAINT UK_tUser_Email UNIQUE(Email),

    CONSTRAINT CK_tUser_Pseudo CHECK(Pseudo <> N''),
    CONSTRAINT CK_tUser_Email CHECK(Email <> N''),
    CONSTRAINT CK_tUser_HashedPassword CHECK(HashedPassword <> N''),
    CONSTRAINT CK_tUser_FirstName CHECK(FirstName <> N''),
    CONSTRAINT CK_tUser_LastName CHECK(LastName <> N'')
);

-- Insert rows into table 'spi.tUser'
INSERT INTO spi.tUser
    ( -- columns to insert data into
    [Pseudo], [Email], [HashedPassword],[FirstName]
    ,[LastName],[BirthDate],[UserType])
VALUES
    ( -- first row: values for the columns in the list above
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        'dummy.email@mail.com',
        CONVERT(VARBINARY(128), newid()),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        '00010101',
        'U'
    );
