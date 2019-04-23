CREATE VIEW spi.vClocks
AS
    -- Select rows from a Table or View 'tClock' in schema 'spi'
    SELECT
        [ClockId] = c.ClockId,
        [Name] = c.Name,
        [GUID] = c.GUID,
        [UserId] = u.UserId,
        [Pseudo] = u.Pseudo,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName
    FROM spi.tClock c LEFT OUTER JOIN spi.tUser u ON c.UserId = u.UserId
    WHERE c.ClockId <> 0
