/*
 * File: 0016.Install-CreateProcedure-sUpdatePreset.sql                        *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:13 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sUpdatePreset' in schema 'spi'
CREATE PROCEDURE spi.sUpdatePreset

    @AlarmPresetId INT,
    @Name NVARCHAR(255),
    @WakingTime TIME,
    @Song NVARCHAR(255),
    @ActivationFlag TINYINT,
    @Challenge INT

AS
BEGIN
    -- body of the stored procedure
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    IF NOT EXISTS (
        -- Select rows from a Table or View 'tAlarmPreset' in schema 'spi'
        SELECT *
    FROM spi.tAlarmPreset
    WHERE AlarmPresetId = @AlarmPresetId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.tAlarmPreset'
    UPDATE spi.tAlarmPreset
    SET
        [WakingTime] = @WakingTime,
        [Name] = @Name,
        [Song] = @Song,
        [ActivationFlag] = @ActivationFlag,
        [Challenge] = @Challenge
    WHERE AlarmPresetId = @AlarmPresetId

    COMMIT
    RETURN 0

END