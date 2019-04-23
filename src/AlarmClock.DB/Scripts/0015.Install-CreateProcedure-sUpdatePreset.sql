-- Create a new stored procedure called 'sUpdatePreset' in schema 'spi'
CREATE PROCEDURE spi.sUpdatePreset

    @AlarmPresetId INT,
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
        -- Select rows from a Table or View 'vPresets' in schema 'spi'
        SELECT *
    FROM spi.vPresets
    WHERE AlarmPresetId = @AlarmPresetId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Update rows in table 'spi.vPresets'
    UPDATE spi.vPresets
    SET
        [WakingTime] = @WakingTime,
        [Song] = @Song,
        [ActivationFlag] = @ActivationFlag,
        [Challenge] = @Challenge
    WHERE AlarmPresetId = @AlarmPresetId

    COMMIT
    RETURN 0

END