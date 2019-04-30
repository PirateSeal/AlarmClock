-- Insert rows into table 'spi.tClock'
INSERT INTO spi.tClock
    (
    [GUID], [Name], UserId
    )
VALUES
    (
        newid(),
        'TestClock-1-'+LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        1
),
    (
        newid(),
        'TestClock-2-'+LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        1

)