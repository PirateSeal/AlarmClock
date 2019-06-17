/*
 * File: 0011.Install-CreateProcedure-sCreateDevice.sql                        *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:05 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sCreateDevice' in schema 'spi'
CREATE PROCEDURE spi.sCreateDevice

    @DeviceId INT out

AS
BEGIN
    -- Insert rows into table 'spi.tDevice'
    INSERT INTO spi.tDevice
        ( [GUID], LastSeenDate )
    VALUES
        ( NEWID(), SYSUTCDATETIME() )
    SET @DeviceId = SCOPE_IDENTITY();
    RETURN 0
END