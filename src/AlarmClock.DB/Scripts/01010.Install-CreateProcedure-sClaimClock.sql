/*
 * File: 01010.Install-CreateProcedure-sClaimClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Friday,5th June 2019 03:30:31 pm                              *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Wednesday, 3rd July 2019 2:59:20 pm                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sClaimClock' in schema 'spi'
CREATE PROCEDURE spi.sClaimClock
    @Guid UNIQUEIDENTIFIER,
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
        spi.tDevice
    WHERE [guid] = @Guid)

    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.tClock'
    UPDATE spi.tClock
        SET
            [UserId] = @UserId
        WHERE [ClockId] = (SELECT
        DeviceId
    FROM
        spi.tDevice
    WHERE [GUID] = @Guid)

    COMMIT
    RETURN 0

END