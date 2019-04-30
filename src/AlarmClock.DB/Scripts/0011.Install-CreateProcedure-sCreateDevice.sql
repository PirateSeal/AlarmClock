-- Create a new stored procedure called 'sCreateDevice' in schema 'spi'
CREATE PROCEDURE spi.sCreateDevice

    @DeviceId INT out

AS
BEGIN
    -- Insert rows into table 'spi.tDevice'
    INSERT INTO spi.tDevice
        ( [GUID], LastSeenDate )
    VALUES
        ( NEWID(), SYSUTCDATETIME() )
    SET @DeviceId = SCOPE_IDENTITY();
    RETURN 0
END