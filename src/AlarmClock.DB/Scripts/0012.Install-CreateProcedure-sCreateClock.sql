-- Create a new stored procedure called 'sCreateClock' in schema 'spi'
CREATE PROCEDURE spi.sCreateClock

    @Name NVARCHAR(255),
    @UserId INT,
    @ClockId INT OUT

AS
BEGIN
    DECLARE @DeviceId INT;

    EXECUTE spi.sCreateDevice @DeviceId OUTPUT;

    -- Insert rows into table 'spi.tClock'
    INSERT INTO spi.tClock
        ( [Name],[UserId] )
    VALUES
        ( @Name, @UserId )
    SET @ClockId = SCOPE_IDENTITY();
    RETURN 0
END
