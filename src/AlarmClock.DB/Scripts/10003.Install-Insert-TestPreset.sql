/*
 * File: 0024.Install-Insert-TestPreset.sql                                    *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 1:04:30 pm                             *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Insert rows into table 'spi.tAlarmPreset'
INSERT INTO spi.tAlarmPreset
    (
    WakingTime,[Name],ActivationFlag,Challenge,Song,ClockId
    )
VALUES
    (
        '00010101', 'RandomName-1' , 0, "Snake", "C2C- Appy.mp3", 1
    
),
    (
        '00010101', 'RandomName-2' , 0, "Math", "C2C- Appy.mp3", 1
    
),
    (
        '00010101', 'RandomName-3' , 0, "Snake", "C2C- Appy.mp3", 2
    
),
    (
        '00010101', 'RandomName-4' , 0, "Math", "C2C- Appy.mp3", 2
    
)
