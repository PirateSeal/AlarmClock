-- Create a new stored procedure called 'sUpdatePreset' in schema 'spi'
CREATE PROCEDURE spi.sUpdateUser

    @UserId INT,
    @Pseudo NVARCHAR(255),
    @HashedPassword VARBINARY(128),
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @BirthDate DATETIME2,
    @UserType CHAR

AS
BEGIN
    -- body of the stored procedure
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'vUsers' in schema 'spi'
        SELECT *
    FROM spi.vUsers
    WHERE UserId = @UserId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.vUsers'
    UPDATE spi.vUsers
    SET
        Pseudo = @Pseudo,
        HashedPassword = @HashedPassword,
        FirstName = @FirstName,
        LastName = @LastName,
        BirthDate = @BirthDate,
        UserType = @UserType
    WHERE UserId = @UserId

    COMMIT
    RETURN 0

END