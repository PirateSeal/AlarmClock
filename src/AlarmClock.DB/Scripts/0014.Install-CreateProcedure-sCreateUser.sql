-- Create a new stored procedure called 'CreateUser' in schema 'spi'
CREATE PROCEDURE spi.CreateUser

    @Pseudo NVARCHAR(255),
    @HashedPassword NVARCHAR(255),
    @Email NVARCHAR(255),
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @BirthDate DATETIME2,
    @UserType INT

AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF EXISTS(
        SELECT *
    FROM spi.tUsers u
    WHERE u.Pseudo = @Pseudo OR (
                u.FirstName = @FirstName
        AND u.LastName = @LastName)
    )
        BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tUsers'
    INSERT INTO spi.tUsers
        ( Pseudo,HashedPassword,Email,FirstName,LastName,BirthDate,UserType )
    VALUES
        (
            @Pseudo, @HashedPassword, @Email, @FirstName, @LastName, @BirthDate, @UserType
    )
    COMMIT
    RETURN 0;
END