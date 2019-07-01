/*
 * File: 0005.Install-CreateTable-tAlarmPreset.sql                             *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 1:18:05 pm                             *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tAlarmPreset' in schema 'spi'
CREATE TABLE spi.tAlarmPreset
(
    AlarmPresetId  INT           IDENTITY(0,1) NOT NULL ,
    -- primary key column
    [Name]         NVARCHAR(255) NOT NULL,
    WakingTime     TIME          NOT NULL,
    Song           NVARCHAR(255) NOT NULL,
    ActivationFlag TINYINT       NOT NULL,
    Challenge      NVARCHAR(255) NOT NULL,
    ClockId        INT           NOT NULL,

    CONSTRAINT PK_AlarmPresetId PRIMARY KEY (AlarmPresetId),

    CONSTRAINT FK_tAlarmPreset_tClock
        FOREIGN KEY (ClockId)
        REFERENCES spi.tClock(ClockId)
);


-- Insert rows into table 'spi.tAlarmPreset'
INSERT INTO spi.tAlarmPreset
    ( -- columns to insert data into
    WakingTime, [Name], Song, ActivationFlag,Challenge, ClockId
    )
VALUES
    (
        '00010101', 'RandomName', "0", 0, "0", 0
    )
