/*
 * File: 0003.Install-CreateTable-tDevice.sql                                  *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:28 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tDevice' in schema 'spi'
CREATE TABLE spi.tDevice
(
    DeviceId     INT              NOT NULL IDENTITY(0,1),
    -- primary key column
    [GUID]       UNIQUEIDENTIFIER NOT NULL,
    LastSeenDate DATETIME2        NOT NULL,

    CONSTRAINT PK_DeviceId PRIMARY KEY (DeviceId)
);


-- Insert rows into table 'spi.tDevice'
INSERT INTO spi.tDevice
    ([GUID], LastSeenDate)
VALUES
    (newid(), '00010101')
