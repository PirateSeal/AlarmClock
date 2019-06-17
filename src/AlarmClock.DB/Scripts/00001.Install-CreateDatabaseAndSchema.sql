/*
 * File: 0001.Install-CreateDatabaseAndSchema.sql                              *
 * Project: Scripts                                                            *
 * File Created: Wednesday,3rd May 2019 04:02:52 pm                            *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:20:56 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new database called 'AlarmClock'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
FROM sys.databases
WHERE name = N'AlarmClock'
)
CREATE DATABASE AlarmClock
GO

USE AlarmClock
GO
CREATE SCHEMA spi
GO