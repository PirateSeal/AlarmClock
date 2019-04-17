CREATE VIEW spi.vPresets
AS
    -- Select rows from a Table or View 'tAlarmPresets' in schema 'spi'
    SELECT
        [ID] = a.AlarmPresetId,
        [WakingTime] = a.WakingTime ,
        [Challenge] = a.Challenge,
        [ActivationFlag] = a.ActivationFlag,
        [Song] = a.Song
    FROM spi.tAlarmPresets a
    WHERE a.AlarmPresetId <> 0
GO