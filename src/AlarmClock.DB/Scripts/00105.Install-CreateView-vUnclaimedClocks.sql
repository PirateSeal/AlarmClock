/*
 * File: 00105.Install-CreateView-vUnclaimedClocks                             *
 * Project: Scripts                                                            *
 * File Created: Monday,1st July 2019 12:04:43 pm                              *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 1st July 2019 12:08:27 pm                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vUnclaimedClocks
AS
    SELECT
        c.ClockId,
        d.GUID,
        c.UserId
    FROM
        spi.tClock c LEFT JOIN spi.tDevice d ON c.ClockId = d.DeviceId
    WHERE c.UserId = 0