-- Create a new stored procedure called 'sDeleteUser' in schema 'spi'
CREATE PROCEDURE spi.sDeleteUser
    @Email NVARCHAR(255)
AS
-- body of the stored procedure
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'vClocks' in schema 'spi'
        SELECT *
    FROM spi.vUsers
    WHERE Email = @Email
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Delete rows from table 'spi.vUsers'
    DELETE FROM spi.vUsers
    WHERE Email = @Email

    COMMIT
    RETURN 0


END