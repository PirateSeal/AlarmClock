/*
 * File: 0015.Install-CreateView-vAuthenticationProvider.sql                   *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 17th June 2019 9:16:48 am                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vAuthenticationProvider
AS
    SELECT

        UserId = u.UserId,
        ProviderName = 'AlarmClock'

    FROM spi.tUser u
    WHERE u.UserId <> 0;