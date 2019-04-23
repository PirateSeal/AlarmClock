-- Create a new table called 'tClockComponent' in schema 'spi'
CREATE TABLE spi.tClockComponent
(
    -- primary key column
    ClockId     INT NOT NULL,
    ComponentId INT NOT NULL,

    CONSTRAINT PK_ClockComponentId PRIMARY KEY(ClockId,ComponentId),

    CONSTRAINT FK_tClockComponent_tClock
        FOREIGN KEY(ClockId)
        REFERENCES spi.tClock(ClockId),
    CONSTRAINT FK_tClockComponent_tComponent
        FOREIGN KEY(ComponentId)
        REFERENCES spi.tComponent (ComponentId)
);
