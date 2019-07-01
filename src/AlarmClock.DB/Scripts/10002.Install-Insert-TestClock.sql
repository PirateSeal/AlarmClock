/*
 * File: 0023.Install-Insert-TestClock.sql                                     *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 10:06:32 am                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

DECLARE @ClockId INT
DECLARE @guid UNIQUEIDENTIFIER = newid()
DECLARE @guid2 UNIQUEIDENTIFIER = newid()

EXECUTE spi.sCreateClock "Test-Clock-1",@guid,1, @ClockId output;
EXECUTE spi.sCreateClock "Test-Clock-2",@guid2, 1, @ClockId output;