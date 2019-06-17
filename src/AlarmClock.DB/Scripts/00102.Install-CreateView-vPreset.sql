/*
 * File: 0010.Install-CreateView-vPreset.sql                                   *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 17th June 2019 9:14:56 am                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vPreset
AS
    -- Select rows from a Table or View 'tAlarmPreset' in schema 'spi'
    SELECT
        [AlarmPresetId]     = a.AlarmPresetId,
        [Name]              = a.Name,
        [WakingTime]        = a.WakingTime ,
        [Challenge]         = c.[Name],
        [ChallengePath]     = c.Path,
        [ActivationFlag]    = a.ActivationFlag,
        [Song]              = s.[Name],
        [SongPath]          = s.Path,
        [ClockId]           = a.ClockId

    FROM spi.tAlarmPreset a
        INNER JOIN spi.tChallenge c ON c.ChallengeId = a.Challenge
        INNER JOIN spi.tSong s ON s.SongId = a.Song
    WHERE a.AlarmPresetId <> 0
