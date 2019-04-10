-- Create a new table called 'tAlarmPresets' in schema 'spi'
CREATE TABLE spi.tAlarmPresets
(
    AlarmPresetId INT           IDENTITY(0,1) NOT NULL ,
    -- primary key column
    WakingTime    TIME          NOT NULL,
    Song          NVARCHAR(255) NOT NULL,
    [Repeat]      BIT           NOT NULL,
    Challenge     INT           NOT NULL,

    CONSTRAINT PK_AlarmPresetId PRIMARY KEY (AlarmPresetId),

);
GO

-- Insert rows into table 'spi.tAlarmPresets'
INSERT INTO spi.tAlarmPresets
    ( -- columns to insert data into
    WakingTime, Song, [Repeat],Challenge
    )
VALUES
    (
        '00010101', 'randomString', 1, 0
    )
GO