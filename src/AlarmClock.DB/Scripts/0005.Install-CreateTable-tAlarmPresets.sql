-- Create a new table called 'tAlarmPresets' in schema 'spi'
CREATE TABLE spi.tAlarmPresets
(
    AlarmPresetId  INT           IDENTITY(0,1) NOT NULL ,
    -- primary key column
    WakingTime     TIME          NOT NULL,
    Song           NVARCHAR(255) NOT NULL,
    ActivationFlag TINYINT       NOT NULL,
    Challenge      INT           NOT NULL,
    ClockId        INT           NOT NULL,

    CONSTRAINT PK_AlarmPresetId PRIMARY KEY (AlarmPresetId),

    CONSTRAINT FK_tAlarmPresets_tClocks
        FOREIGN KEY (ClockId)
        REFERENCES spi.tClocks(ClockId)
);
GO

-- Insert rows into table 'spi.tAlarmPresets'
INSERT INTO spi.tAlarmPresets
    ( -- columns to insert data into
    WakingTime, Song, ActivationFlag,Challenge, ClockId
    )
VALUES
    (
        '00010101', 'randomString', 0, 0, 0
    )
GO