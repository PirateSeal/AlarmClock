CREATE VIEW spi.vClocks
AS
    -- Select rows from a Table or View 'tRegisteredClocks' in schema 'spi'
    SELECT
        [ID] = c.RegisteredClockId,
        [Name] = c.Name,
        [GUID] = c.GUID,
        [Pseudo] = u.Pseudo,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName
    FROM spi.tRegisteredClocks c LEFT OUTER JOIN spi.tUsers u ON c.UserId = u.UserId
    WHERE c.RegisteredClockId <> 0
GO