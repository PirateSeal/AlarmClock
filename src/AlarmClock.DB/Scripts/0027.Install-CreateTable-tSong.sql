/*
 * File: 0027.Install-CreateTable-tSong.sql                                    *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th June 2019 09:35:02 am                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:41:54 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tSong' in schema 'spi'
CREATE TABLE spi.tSong
(
    SongId INT           NOT NULL ,
    -- primary key column

    [Name] NVARCHAR(20)  NOT NULL,
    Artist NVARCHAR(50)  NULL,
    Genre  NVARCHAR(20)  NULL,
    Album  NVARCHAR(20)  NULL,
    [Path] NVARCHAR(255) NOT NULL,

    CONSTRAINT PK_SongId PRIMARY KEY (SongId)
);