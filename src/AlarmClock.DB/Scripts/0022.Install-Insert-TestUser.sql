/*
 * File: 0022.Install-Insert-TestUser.sql                                      *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:18:20 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Insert rows into table 'spi.tUser'
INSERT INTO spi.tUser
    (
    Pseudo, HashedPassword, Email, FirstName,LastName,BirthDate,UserType
    )
VALUES
    (
        'PirateSeal', 0x01000000010000271000000010015F29C3687663657F3BBE86EA5C834C4DABDC457AF5538BBD2E2F40A85CC7DE05C1AE150818FBFC46D4A23D0C65BEBB, 'admin@admin.admin', 'Pirate', 'Seal', '00010101', 'A'
    ),
    (
        'ADMIN'+LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        CONVERT(VARBINARY(128), newid()),
        'TestUser.email@mail.com',
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        '00010101',
        'U'
)