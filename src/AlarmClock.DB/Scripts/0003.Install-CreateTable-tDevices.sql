-- Create a new table called 'tDevices' in schema 'spi'
CREATE TABLE spi.tDevices
(
    DeviceId     INT              NOT NULL IDENTITY(0,1),
    -- primary key column
    [GUID]       UNIQUEIDENTIFIER NOT NULL,
    LastSeenDate DATETIME2        NOT NULL,

    CONSTRAINT PK_DeviceId PRIMARY KEY (DeviceId)
);
GO

-- Insert rows into table 'spi.tDevices'
INSERT INTO spi.tDevices
    ([GUID], LastSeenDate)
VALUES
    (newid(), '00010101')
GO