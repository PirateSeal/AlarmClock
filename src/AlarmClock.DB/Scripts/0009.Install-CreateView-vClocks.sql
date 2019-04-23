CREATE VIEW spi.vClocks
AS
    -- Select rows from a Table or View 'tClocks' in schema 'spi'
    SELECT
        [ClockId] = c.ClockId,
        [Name] = c.Name,
        [GUID] = c.GUID,
        [Pseudo] = u.Pseudo,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName
    FROM spi.tClocks c LEFT OUTER JOIN spi.tUsers u ON c.UserId = u.UserId
    WHERE c.ClockId <> 0
GO