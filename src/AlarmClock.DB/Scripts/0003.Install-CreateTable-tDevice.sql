-- Create a new table called 'tDevice' in schema 'spi'
CREATE TABLE spi.tDevice
(
    DeviceId     INT              NOT NULL IDENTITY(0,1),
    -- primary key column
    [GUID]       UNIQUEIDENTIFIER NOT NULL,
    LastSeenDate DATETIME2        NOT NULL,

    CONSTRAINT PK_DeviceId PRIMARY KEY (DeviceId)
);


-- Insert rows into table 'spi.tDevice'
INSERT INTO spi.tDevice
    ([GUID], LastSeenDate)
VALUES
    (newid(), '00010101')
