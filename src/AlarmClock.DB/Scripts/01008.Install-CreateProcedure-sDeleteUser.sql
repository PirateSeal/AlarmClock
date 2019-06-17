/*
 * File: 0019.Install-CreateProcedure-sDeleteUser.sql                          *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:18:46 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sDeleteUser' in schema 'spi'
CREATE PROCEDURE spi.sDeleteUser
    @Email NVARCHAR(255),
    @HashedPassword VARBINARY(128)
AS
-- body of the stored procedure
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'tUser' in schema 'spi'
        SELECT *
    FROM spi.tUser
    WHERE Email = @Email
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Delete rows from table 'spi.tUser'
    DELETE FROM spi.tUser
    WHERE Email = @Email AND HashedPassword = @HashedPassword

    COMMIT
    RETURN 0


END
