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
        [ClockGuid] = d.GUID,
        [LastSeenDate] = d.LastSeenDate,

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
        LEFT JOIN spi.tClock c ON c.UserId = u.UserId AND c.ClockId <> 0
        LEFT JOIN spi.tDevice d ON d.DeviceId = c.ClockId
        LEFT JOIN spi.tAlarmPreset a ON c.ClockId = a.ClockId AND a.AlarmPresetId <> 0

    WHERE u.UserId <> 0
