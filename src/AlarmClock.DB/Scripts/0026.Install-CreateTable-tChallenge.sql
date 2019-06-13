/*
 * File: 0026.Install-CreateTable-tChallenge.sql                               *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th June 2019 09:17:44 am                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:32:57 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tChallenge' in schema 'spi'
CREATE TABLE spi.tChallenge
(
    ChallengeId   INT             NOT NULL ,
    -- primary key column

    [Name]        [NVARCHAR](20)  NOT NULL,
    [Description] [NVARCHAR](255) NULL,
    [Path]        [NVARCHAR](255) NOT NULL,

    CONSTRAINT PK_ChallengeId PRIMARY KEY (ChallengeId)
);