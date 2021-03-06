-- Create a new stored procedure called 'sDeletePreset' in schema 'spi'
CREATE PROCEDURE spi.sDeletePreset
    @AlarmPresetId NVARCHAR(255)
AS
-- body of the stored procedure
BEGIN
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

    -- Delete rows from table 'spi.tAlarmPreset'
    DELETE FROM spi.tAlarmPreset
    WHERE AlarmPresetId = @AlarmPresetId

    COMMIT
    RETURN 0


END