-- Create a new stored procedure called 'sCreateClock' in schema 'spi'
CREATE PROCEDURE spi.sCreateClock

    @Name NVARCHAR(255),
    @GUID NVARCHAR(255),
    @UserId INT

AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRAN

    IF EXISTS (
        -- Select rows from a Table or View 'tRegisteredClocks' in schema 'spi'
        SELECT *
    FROM spi.tRegisteredClocks r
    WHERE r.GUID = @GUID	
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tRegisteredClocks'
    INSERT INTO spi.tRegisteredClocks
        ( [Name],[GUID],[UserId] )
    VALUES
        ( @Name, @GUID, @UserId )
    COMMIT
    RETURN 0
END