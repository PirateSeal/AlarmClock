/*
 * File: 0017.Install-CreateProcedure-sUpdateUser.sql                          *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:14 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

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
        -- Select rows from a Table or View 'tUser' in schema 'spi'
        SELECT *
    FROM spi.tUser
    WHERE UserId = @UserId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.tUser'
    UPDATE spi.tUser
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
