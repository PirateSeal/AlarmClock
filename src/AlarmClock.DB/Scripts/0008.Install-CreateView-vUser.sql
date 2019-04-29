CREATE VIEW spi.vUser
AS
    -- Select rows from a Table or View 'tUser' in schema 'spi'
    SELECT
        [UserId] = u.UserId,
        [Email] = u.Email,
        [Pseudo] = u.Pseudo,
        [HashedPassword] = u.HashedPassword,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName,
        [BirthDate] = u.BirthDate,
        [UserType] = u.UserType
    FROM spi.tUser u
    WHERE u.UserId <> 0
