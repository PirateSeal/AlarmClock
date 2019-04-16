-- Create a new stored procedure called 'sCreatePreset' in schema 'spi'
CREATE PROCEDURE spi.sCreatePreset
    @WakingTime TIME,
    @Song NVARCHAR(255),
    @ActivationFlag TINYINT,
    @Challenge INT,
    @ClockId INT
AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRAN

    IF EXISTS (
        -- Select rows from a Table or View 'tAlarmPresets' in schema 'spi'
        SELECT *
    FROM spi.tAlarmPresets
    WHERE WakingTime = @WakingTime AND ClockId = @ClockId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tAlarmPresets'
    INSERT INTO spi.tAlarmPresets
        ( [WakingTime],[Song],[ActivationFlag],[Challenge],[ClockId] )
    VALUES
        ( @WakingTime, @Song, @ActivationFlag, @Challenge, @ClockId )
    COMMIT
    RETURN 0
END