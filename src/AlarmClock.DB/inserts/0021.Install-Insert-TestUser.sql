-- Insert rows into table 'spi.tUser'
INSERT INTO spi.tUser
    (
    Pseudo, HashedPassword, Email, FirstName,LastName,BirthDate,UserType
    )
VALUES
    (
        'TestUser-'+LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        CONVERT(VARBINARY(128), newid()),
        'TestUser.email@mail.com',
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        '00010101',
        'U')
