/*
 * File: 0020.Install-CreateProcedure-sDeleteClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:18:43 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sDeleteClock' in schema 'spi'
CREATE PROCEDURE spi.sDeleteClock
    @ClockId INT
AS
-- body of the stored procedure
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'tClock' in schema 'spi'
        SELECT *
    FROM spi.tClock
    WHERE [ClockId] = @ClockId
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Delete rows from table 'spi.tClock'
    DELETE FROM spi.tClock
    WHERE [ClockId] = @ClockId

    COMMIT
    RETURN 0


END