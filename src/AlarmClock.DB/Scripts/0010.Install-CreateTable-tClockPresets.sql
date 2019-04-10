-- Create a new table called 'tClockPresets' in schema 'spi'
-- Drop the table if it already exists
IF OBJECT_ID('spi.tClockPresets', 'U') IS NOT NULL
DROP TABLE spi.tClockPresets
GO
-- Create the table in the specified schema
CREATE TABLE spi.tClockPresets
(
    ClockPresetId INT NOT NULL ,
    -- primary key column
    ClockId       INT NOT NULL,
    PresetId      INT NOT NULL,

    CONSTRAINT PK_ClockPresetId PRIMARY KEY(ClockPresetId),

    CONSTRAINT FK_tClockPresets_tRegisteredClocks
        FOREIGN KEY(ClockId)
        REFERENCES spi.tRegisteredClocks(RegisteredClockId),
    CONSTRAINT FK_tClockPresets_tAlarmPresets
        FOREIGN KEY(PresetId)
        REFERENCES spi.tAlarmPresets(AlarmPresetId)
);
GO