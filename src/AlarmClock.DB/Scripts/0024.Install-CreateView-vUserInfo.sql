CREATE VIEW spi.vUserInfo
AS
    SELECT

        -- User Data
        [UserId] = u.UserId,
        [Pseudo] = u.Pseudo,
        [Email] = u.Email,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName,
        [BirthDate] = u.BirthDate,

        -- Clock Data
        [ClockId] = c.ClockId,
        [ClockName] = c.Name,
        [ClockGuid] = c.GUID,

        -- Preset Data
        [PresetId] = a.AlarmPresetId,
        [PresetName] = a.Name,
        [WakingTime]= a.WakingTime,
        [ActivationFlag] = a.ActivationFlag,
        [Challenge] = a.Challenge,
        [Song] = a.Song,
        [PresetClockId] = a.ClockId

    FROM
        spi.tUser u
        JOIN spi.tClock c
        ON u.UserId = c.UserId
        JOIN spi.tAlarmPreset a
        ON c.ClockId = a.ClockId

    WHERE u.UserId <> 0 AND c.ClockId <> 0 AND a.AlarmPresetId <> 0