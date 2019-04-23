-- Create a new table called 'tComponent' in schema 'spi'
CREATE TABLE spi.tComponent
(
    ComponentId INT           IDENTITY(0,1) NOT NULL ,
    -- primary key column
    [Name]      NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_ComponentId PRIMARY KEY(ComponentId),

    CONSTRAINT UK_tComponent_Name UNIQUE([Name])
);


-- Insert rows into table 'spi.tComponent'
INSERT INTO spi.tComponent
    ( -- columns to insert data into
    [Name]
    )
VALUES
    -- first row: values for the columns in the list above
    ('Microphone'),
    ('Speaker'),
    ('Screen'),
    ('Tactile Screen')
