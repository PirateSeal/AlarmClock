/*
 * File: 0012.Install-CreateProcedure-sCreateClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 9:49:15 am                             *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sCreateClock' in schema 'spi'
CREATE PROCEDURE spi.sCreateClock

    @Name NVARCHAR(255),
    @GUID UNIQUEIDENTIFIER,
    @UserId INT,
    @ClockId INT OUT

AS
BEGIN
    DECLARE @DeviceId INT;

    EXECUTE spi.sCreateDevice @GUID, @DeviceId OUTPUT;

    -- Insert rows into table 'spi.tClock'
    INSERT INTO spi.tClock
        ([Name],[UserId] )
    VALUES
        ( @Name, @UserId )
    SET @ClockId = SCOPE_IDENTITY();
    RETURN 0
END
