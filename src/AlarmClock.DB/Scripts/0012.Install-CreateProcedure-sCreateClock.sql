/*
 * File: 0012.Install-CreateProcedure-sCreateClock.sql                         *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:07 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sCreateClock' in schema 'spi'
CREATE PROCEDURE spi.sCreateClock

    @Name NVARCHAR(255),
    @UserId INT,
    @ClockId INT OUT

AS
BEGIN
    DECLARE @DeviceId INT;

    EXECUTE spi.sCreateDevice @DeviceId OUTPUT;

    -- Insert rows into table 'spi.tClock'
    INSERT INTO spi.tClock
        ( [Name],[UserId] )
    VALUES
        ( @Name, @UserId )
    SET @ClockId = SCOPE_IDENTITY();
    RETURN 0
END
