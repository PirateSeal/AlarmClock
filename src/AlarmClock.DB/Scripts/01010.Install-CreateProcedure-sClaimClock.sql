/*
 * File: 01010.Install-CreateProcedure-sClaimClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Friday,5th June 2019 03:30:31 pm                              *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 1:11:33 pm                             *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sClaimClock' in schema 'spi'
CREATE PROCEDURE spi.sClaimClock
    @ClockId INT ,
    @UserId INT

AS
BEGIN
    -- body of the stored procedure
    SET TRANSACTION ISOLATION level serializable;
    BEGIN TRAN;

    IF NOT EXISTS (
        SELECT
        *
    FROM
        spi.tClock
    WHERE [ClockId] = @ClockId)

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.tClock'
    UPDATE spi.tClock
        SET
            [UserId] = @UserId
        WHERE [ClockId] = @ClockId

    UPDATE spi.tDevice
        SET
         [LastSeenDate] = GETDATE()
        WHERE [DeviceId] = @ClockId

    COMMIT
    RETURN 0

END
