/*
 * File: 0023.Install-Insert-TestClock.sql                                     *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:18:15 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

DECLARE @ClockId INT

EXECUTE spi.sCreateClock "Test-Clock-1",1, @ClockId output;
EXECUTE spi.sCreateClock "Test-Clock-2", 1, @ClockId output;