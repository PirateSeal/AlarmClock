-- Create a new table called 'tClocks' in schema 'spi'
CREATE TABLE spi.tClocks
(
    ClockId INT              NOT NULL IDENTITY(0,1),
    -- primary key column
    [Name]  NVARCHAR(255)    NOT NULL,
    [GUID]  UNIQUEIDENTIFIER NOT NULL,
    UserId  INT              NOT NULL,

    CONSTRAINT PK_ClockId PRIMARY KEY(ClockId),

    CONSTRAINT FK_tClocks_tDevices
        FOREIGN KEY(ClockId)
        REFERENCES spi.tDevices(DeviceId),
    CONSTRAINT FK_tClocks_tUsers
        FOREIGN KEY (UserId)
        REFERENCES spi.tUsers(UserId),

    CONSTRAINT UK_tClocks_Name UNIQUE([Name]),
    CONSTRAINT UK_tClocks_GUID UNIQUE([GUID])
);
GO

-- Insert rows into table 'spi.Clocks'
INSERT INTO spi.tClocks
    ( -- columns to insert data into
    [Name], [GUID], UserId
    )
VALUES
    (
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        newid(),
        0
)
GO