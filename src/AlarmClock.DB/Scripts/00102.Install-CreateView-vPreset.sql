/*
 * File: 0010.Install-CreateView-vPreset.sql                                   *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 1:00:45 pm                             *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vPreset
AS
    -- Select rows from a Table or View 'tAlarmPreset' in schema 'spi'
    SELECT
        [AlarmPresetId]     = a.AlarmPresetId,
        [Name]              = a.Name,
        [WakingTime]        = a.WakingTime ,
        [Challenge]         = a.[Challenge],
        [ActivationFlag]    = a.ActivationFlag,
        [Song]              = a.Song,
        [ClockId]           = a.ClockId

    FROM
        spi.tAlarmPreset a
    WHERE a.AlarmPresetId <> 0
