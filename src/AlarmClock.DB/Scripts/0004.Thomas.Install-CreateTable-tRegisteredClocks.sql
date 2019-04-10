-- Create a new table called 'tRegisteredClocks' in schema 'spi'
CREATE TABLE spi.tRegisteredClocks
(
    RegisteredClockId INT           NOT NULL IDENTITY(0,1),
    -- primary key column
    [Name]            NVARCHAR(255) NOT NULL,
    [GUID]            NVARCHAR(255) NOT NULL,
    PresetId          INT           NULL,

    CONSTRAINT PK_RegisteredClockId PRIMARY KEY(RegisteredClockId),

    CONSTRAINT UK_tRegisteredClocks_Name UNIQUE([Name]),
    CONSTRAINT UK_tRegisteredClocks_GUID UNIQUE([GUID])
);
GO

-- Insert rows into table 'spi.RegisteredClocks'
INSERT INTO spi.RegisteredClocks
    ( -- columns to insert data into
    [Name], [GUID]
    )
VALUES
    (
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32)
),
    (
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32) 
)
GO