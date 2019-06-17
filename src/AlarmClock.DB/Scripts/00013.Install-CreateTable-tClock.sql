/*
 * File: 0004.Install-CreateTable-tClock.sql                                   *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:25 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tClock' in schema 'spi'
CREATE TABLE spi.tClock
(
    ClockId INT           NOT NULL IDENTITY(0,1),
    -- primary key column
    [Name]  NVARCHAR(255) NOT NULL,
    UserId  INT           NOT NULL,

    CONSTRAINT PK_ClockId PRIMARY KEY(ClockId),

    CONSTRAINT FK_tClock_tDevice 
        FOREIGN KEY (ClockId) 
        REFERENCES spi.tDevice (DeviceId),

    CONSTRAINT FK_tClock_tUser
        FOREIGN KEY (UserId)
        REFERENCES spi.tUser(UserId),

);

-- Insert rows into table 'spi.Clocks'
INSERT INTO spi.tClock
    ( -- columns to insert data into
    [Name], UserId
    )
VALUES
    (

        LEFT(CONVERT(NVARCHAR(36), newid()), 32),
        0
)
