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

GO