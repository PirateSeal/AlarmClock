CREATE VIEW spi.vClock
AS
    -- Select rows from a Table or View 'tClock' in schema 'spi'
    SELECT
        [ClockId] = c.ClockId,
        [Name] = c.Name,
        [GUID] = c.GUID,
        [UserId] = c.UserId
    FROM spi.tClock c
    WHERE c.ClockId <> 0
