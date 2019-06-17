/*
 * File: 0009.Install-CreateView-vClock.sql                                    *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 17th June 2019 9:15:19 am                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vClock
AS
    -- Select rows from a Table or View 'tClock' in schema 'spi'
    SELECT
        [ClockId]   = c.ClockId,
        [Name]      = c.Name,
        [UserId]    = c.UserId
    FROM spi.tClock c
    WHERE c.ClockId <> 0
