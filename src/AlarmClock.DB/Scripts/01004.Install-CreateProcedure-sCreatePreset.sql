/*
 * File: 0014.Install-CreateProcedure-sCreatePreset.sql                        *
 * Project: Scripts                                                            *
 * File Created: Thursday,4th May 2019 09:07:47 am                             *
 * Author: Le Phoque Pirate                                                    *
 * --------------------                                                        *
 * Last Modified: Thursday, 13th June 2019 9:19:10 am                          *
 * Modified By: Le Phoque Pirate (tcousin@intechinfo.fr)                       *
 */

-- Create a new stored procedure called 'sCreatePreset' in schema 'spi'
CREATE PROCEDURE spi.sCreatePreset
    @WakingTime TIME,
    @Name NVARCHAR(255),
    @Song NVARCHAR(255),
    @ActivationFlag TINYINT,
    @Challenge INT,
    @ClockId INT,
    @AlarmPresetId INT OUT

AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRAN

    IF EXISTS (
        -- Select rows from a Table or View 'tAlarmPreset' in schema 'spi'
        SELECT *
    FROM spi.tAlarmPreset
    WHERE WakingTime = @WakingTime AND ClockId = @ClockId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tAlarmPreset'
    INSERT INTO spi.tAlarmPreset
        ( [WakingTime],[Name],[Song],[ActivationFlag],[Challenge],[ClockId] )
    VALUES
        ( @WakingTime, @Name, @Song, @ActivationFlag, @Challenge, @ClockId )
    SET @AlarmPresetId = SCOPE_IDENTITY();
    COMMIT
    RETURN 0
END