/*
 * File: 0024.Install-Insert-TestPreset.sql                                    *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:18:07 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Insert rows into table 'spi.tAlarmPreset'
INSERT INTO spi.tAlarmPreset
    (
    WakingTime,[Name],ActivationFlag,Challenge,Song,ClockId
    )
VALUES
    (
        '00010101', 'RandomName-1' , 0, 0, 'TestSong', 1
    
),
    (
        '00010101', 'RandomName-2' , 0, 0, 'TestSong 2', 1
    
),
    (
        '00010101', 'RandomName-3' , 0, 0, 'TestSong 3', 2
    
),
    (
        '00010101', 'RandomName-4' , 0, 0, 'TestSong 4', 2
    
)
