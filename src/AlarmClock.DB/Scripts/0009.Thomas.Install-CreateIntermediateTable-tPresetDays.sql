-- Create a new table called 'tPresetDays' in schema 'spi'
CREATE TABLE spi.tPresetDays
(
    PresetDayId INT NOT NULL,
    -- primary key column
    PresetId    INT NOT NULL,
    DayId       INT NOT NULL,

    CONSTRAINT PK_PresetDayId PRIMARY KEY(PresetDayId),

    CONSTRAINT FK_tPresetDays_tAlarmPreset
        FOREIGN KEY (PresetId)
        REFERENCES spi.tAlarmPreset(AlarmPresetId),
    CONSTRAINT FK_tPresetDays_tDays
        FOREIGN KEY(DayId)
        REFERENCES spi.tDays(DayId)
);
GO