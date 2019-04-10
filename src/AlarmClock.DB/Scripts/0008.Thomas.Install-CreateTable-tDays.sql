-- Create a new table called 'tDays' in schema 'spi'
CREATE TABLE spi.tDays
(
    DayId  INT           IDENTITY(0,1) NOT NULL,
    -- primary key column
    [Name] NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_DayId PRIMARY KEY(DayId),

    CONSTRAINT UK_tDays_Name UNIQUE([Name])
);
GO

-- Insert rows into table 'spi.tDays'
INSERT INTO spi.tDays
    ([Name])
VALUES
    ('lundi'),
    ('Mardi'),
    ('Mercredi'),
    ('Jeudi'),
    ('Vendredi'),
    ('Samedi'),
    ('Dimanche')
GO