/*
 * File: 0008.Install-CreateView-vUser.sql                                     *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:58 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

CREATE VIEW spi.vUser
AS
    -- Select rows from a Table or View 'tUser' in schema 'spi'
    SELECT
        [UserId] = u.UserId,
        [Email] = u.Email,
        [Pseudo] = u.Pseudo,
        [HashedPassword] = u.HashedPassword,
        [FirstName] = u.FirstName,
        [LastName] = u.LastName,
        [BirthDate] = u.BirthDate,
        [UserType] = u.UserType
    FROM spi.tUser u
    WHERE u.UserId <> 0
