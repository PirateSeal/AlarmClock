/*
 * File: 0026.Install-CreateTable-tChallenge.sql                               *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th June 2019 09:17:44 am                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Monday, 17th June 2019 9:23:42 am                            *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new table called 'tChallenge' in schema 'spi'
CREATE TABLE spi.tChallenge
(
    ChallengeId   INT             NOT NULL IDENTITY(0,1),
    -- primary key column

    [Name]        [NVARCHAR](20)  NOT NULL,
    [Description] [NVARCHAR](255) NULL,
    [Path]        [NVARCHAR](255) NOT NULL,

    CONSTRAINT PK_ChallengeId PRIMARY KEY (ChallengeId)
);

-- Insert rows into table 'spi.tChallenge'
INSERT INTO spi.tChallenge
    (
    [Name],[Description],[Path]
    )
VALUES
    (
        'Random',
        'Random',
        'Random'
    )