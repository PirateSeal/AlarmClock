CREATE VIEW spi.vPreset
AS
    -- Select rows from a Table or View 'tAlarmPreset' in schema 'spi'
    SELECT
        [AlarmPresetId] = a.AlarmPresetId,
        [WakingTime] = a.WakingTime ,
        [Challenge] = a.Challenge,
        [ActivationFlag] = a.ActivationFlag,
        [Song] = a.Song,
        [ClockId] = a.ClockId
    FROM spi.tAlarmPreset a
    WHERE a.AlarmPresetId <> 0
