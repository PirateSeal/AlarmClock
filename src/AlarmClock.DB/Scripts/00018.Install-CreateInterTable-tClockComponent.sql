/*
 * File: 0007.Install-CreateInterTable-tClockComponent.sql                     *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:49 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tClockComponent' in schema 'spi'
CREATE TABLE spi.tClockComponent
(
    -- primary key column
    ClockId     INT NOT NULL,
    ComponentId INT NOT NULL,

    CONSTRAINT PK_ClockComponentId PRIMARY KEY(ClockId,ComponentId),

    CONSTRAINT FK_tClockComponent_tClock
        FOREIGN KEY(ClockId)
        REFERENCES spi.tClock(ClockId),
    CONSTRAINT FK_tClockComponent_tComponent
        FOREIGN KEY(ComponentId)
        REFERENCES spi.tComponent (ComponentId)
);
