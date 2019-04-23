-- Create a new stored procedure called 'sUpdateClock' in schema 'spi'
CREATE PROCEDURE spi.sUpdateClock

    @ClockId INT,
    @Name NVARCHAR(255)

AS
BEGIN
    -- body of the stored procedure
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'tClock' in schema 'spi'
        SELECT *
    FROM spi.tClock
    WHERE ClockId = @ClockId
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.tClock'
    UPDATE spi.tClock
    SET
    [Name]=@Name
    WHERE ClockId = @ClockId

    COMMIT
    RETURN 0

END
