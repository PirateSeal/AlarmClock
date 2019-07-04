/*
 * File: 0020.Install-CreateProcedure-sDeleteClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 4th July 2019 12:09:47 pm                          *
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
        SELECT
        *
    FROM
        spi.tClock
    WHERE [ClockId] = @ClockId
    )

    BEGIN
        ROLLBACK
        RETURN 1
    END

    BEGIN

        -- Delete rows from table 'spi.tAlarmPreset'
        DELETE FROM spi.tAlarmPreset
    WHERE [ClockId] = @ClockId

    END

    BEGIN

        UPDATE spi.tClock
            SET [UserId] = 0
        WHERE [ClockId] = @ClockId

    END

    COMMIT
    RETURN 0


END