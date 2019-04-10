-- Create a new table called 'tClockComponents' in schema 'spi'
CREATE TABLE spi.tClockComponents
(
    ClockComponentId INT NOT NULL IDENTITY(0,1),
    -- primary key column
    ClockId          INT NOT NULL,
    ComponentId      INT NOT NULL,

    CONSTRAINT PK_ClockComponentId PRIMARY KEY(ClockComponentId),

    CONSTRAINT FK_tClockComponents_tRegisteredClocks
        FOREIGN KEY(ClockId)
        REFERENCES spi.tRegisteredClocks(RegisteredClockId),
    CONSTRAINT FK_tClockComponents_tComponents
        FOREIGN KEY(ComponentId)
        REFERENCES spi.tComponents (ComponentId)
);
GO