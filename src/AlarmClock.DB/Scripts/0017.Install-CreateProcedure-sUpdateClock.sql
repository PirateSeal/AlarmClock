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
        -- Select rows from a Table or View 'vClocks' in schema 'spi'
        SELECT *
    FROM spi.vClocks
    WHERE ClockId = @ClockId
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.vClocks'
    UPDATE spi.vClocks
    SET
    [Name]=@Name
    WHERE ClockId = @ClockId

    COMMIT
    RETURN 0

END