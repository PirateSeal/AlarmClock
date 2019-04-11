CREATE VIEW spi.vUsers
AS
    -- Select rows from a Table or View 'tUsers' in schema 'spi'
    SELECT
        [ID] = u.UserId,
        [Email] = u.Email,
        [Pseudo] = u.Pseudo,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName,
        [BirthDate] = u.BirthDate,
        [UserType] = u.UserType
    FROM spi.tUsers u
    WHERE u.UserId <> 0
GO