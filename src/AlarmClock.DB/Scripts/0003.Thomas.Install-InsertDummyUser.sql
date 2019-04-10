-- Insert rows into table 'spi.tUsers'
INSERT INTO spi.tUsers
    ( -- columns to insert data into
    [Pseudo], [Email], [HashedPassword],[FirstName]
    ,[LastName],[BirthDate],[UserType])
VALUES
    ( -- first row: values for the columns in the list above
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        'dummy.email@mail.com',
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        '00010101',
        0
    );
GO