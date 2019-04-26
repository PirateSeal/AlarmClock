-- Create a new table called 'tAlarmPreset' in schema 'spi'
CREATE TABLE spi.tAlarmPreset
(
    AlarmPresetId  INT           IDENTITY(0,1) NOT NULL ,
    -- primary key column
    [Name]         NVARCHAR(255) NOT NULL,
    WakingTime     TIME          NOT NULL,
    Song           NVARCHAR(255) NOT NULL,
    ActivationFlag TINYINT       NOT NULL,
    Challenge      INT           NOT NULL,
    ClockId        INT           NOT NULL,

    CONSTRAINT PK_AlarmPresetId PRIMARY KEY (AlarmPresetId),

    CONSTRAINT FK_tAlarmPreset_tClock
        FOREIGN KEY (ClockId)
        REFERENCES spi.tClock(ClockId)
);


-- Insert rows into table 'spi.tAlarmPreset'
INSERT INTO spi.tAlarmPreset
    ( -- columns to insert data into
    WakingTime, Song, ActivationFlag,Challenge, ClockId
    )
VALUES
    (
        '00010101', 'randomString', 0, 0, 0
    )
