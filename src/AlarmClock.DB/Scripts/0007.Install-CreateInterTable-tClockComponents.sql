-- Create a new table called 'tClockComponents' in schema 'spi'
CREATE TABLE spi.tClockComponents
(
    -- primary key column
    ClockId     INT NOT NULL,
    ComponentId INT NOT NULL,

    CONSTRAINT PK_ClockComponentId PRIMARY KEY(ClockId,ComponentId),

    CONSTRAINT FK_tClockComponents_tClocks
        FOREIGN KEY(ClockId)
        REFERENCES spi.tClocks(ClockId),
    CONSTRAINT FK_tClockComponents_tComponents
        FOREIGN KEY(ComponentId)
        REFERENCES spi.tComponents (ComponentId)
);
GO