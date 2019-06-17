/*
 * File: 0013.Install-CreateProcedure-sCreateUser.sql                          *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:20 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'CreateUser' in schema 'spi'
CREATE PROCEDURE spi.sCreateUser

    @Pseudo NVARCHAR(255),
    @HashedPassword VARBINARY(128) ,
    @Email NVARCHAR(255),
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
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
    FROM spi.tUser u
    WHERE u.Email = @Email
    )
        BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tUser'
    INSERT INTO spi.tUser
        ( Pseudo,HashedPassword,Email,FirstName,LastName,BirthDate,UserType )
    VALUES
        (
            @Pseudo, @HashedPassword, @Email, @FirstName, @LastName, @BirthDate, @UserType
    )
    SET @UserId = SCOPE_IDENTITY()
    COMMIT
    RETURN 0;
END
