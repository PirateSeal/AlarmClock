-- Create a new stored procedure called 'sCreatePreset' in schema 'spi'
CREATE PROCEDURE spi.sCreatePreset
    @WakingTime TIME,
    @Song NVARCHAR(255),
    @Repeat BIT,
    @Challenge INT,
    @UserId INT
AS
BEGIN
    -- body of the stored procedure

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
    BEGIN TRAN

    IF EXISTS (
        -- Select rows from a Table or View 'tAlarmPresets' in schema 'spi'
        SELECT *
    FROM spi.tAlarmPresets
    WHERE WakingTime = @WakingTime AND UserId = @UserId
    )
    
    BEGIN
        ROLLBACK
        RETURN 1
    END

    -- Insert rows into table 'spi.tAlarmPresets'
    INSERT INTO spi.tAlarmPresets
        ( [WakingTime],[Song],[Repeat],[Challenge],[UserId] )
    VALUES
        ( @WakingTime, @Song, @Repeat, @Challenge, @UserId )
    COMMIT
    RETURN 0
END