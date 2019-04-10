-- Create a new table called 'tAlarmPreset' in schema 'spi'
CREATE TABLE spi.tAlarmPreset
(
    AlarmPresetId INT       NOT NULL ,
    -- primary key column
    WakingTime    DATETIME2 NOT NULL,
    Recurrence    INT       NOT NULL,

    CONSTRAINT PK_AlarmPresetId PRIMARY KEY (AlarmPresetId)
);
GO