-- Create a new stored procedure called 'CreateUser' in schema 'spi'
CREATE PROCEDURE spi.sCreateUser

    @Pseudo NVARCHAR(255),
    @HashedPassword VARBINARY(128) ,
    @Email NVARCHAR(255),
    @FirstName NVARCHAR = "tutu",
    @LastName NVARCHAR = "toto",
    @BirthDate DATETIME2,
    @UserType CHAR = 'U',
    @UserId INT OUT

AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF EXISTS(
        SELECT *
    FROM spi.tUsers u
    WHERE u.Email = @Email
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
    SET @UserId = SCOPE_IDENTITY()
    COMMIT
    RETURN 0;
END
