-- Create a new stored procedure called 'sDeleteClock' in schema 'spi'
CREATE PROCEDURE spi.sDeleteClock
    @Name NVARCHAR(255)
AS
-- body of the stored procedure
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'tClock' in schema 'spi'
        SELECT *
    FROM spi.tClock
    WHERE [Name] = @Name
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Delete rows from table 'spi.tClock'
    DELETE FROM spi.tClock
    WHERE [Name] = @Name

    COMMIT
    RETURN 0


END