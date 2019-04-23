-- Create a new stored procedure called 'sCreateClock' in schema 'spi'
CREATE PROCEDURE spi.sCreateClock

    @Name NVARCHAR(255),
    @GUID NVARCHAR(255),
    @UserId INT,
    @ClockId INT out

AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRAN

    IF EXISTS (
        -- Select rows from a Table or View 'tClock' in schema 'spi'
        SELECT *
    FROM spi.tClock r
    WHERE r.GUID = @GUID	
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tClock'
    INSERT INTO spi.tClock
        ( [Name],[GUID],[UserId] )
    VALUES
        ( @Name, @GUID, @UserId )
    SET @ClockId = SCOPE_IDENTITY();
    COMMIT
    RETURN 0
END