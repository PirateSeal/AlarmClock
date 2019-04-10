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