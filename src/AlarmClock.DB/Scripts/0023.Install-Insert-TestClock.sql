DECLARE @ClockId INT

EXECUTE spi.sCreateClock "Test-Clock-1",1, @ClockId output;
EXECUTE spi.sCreateClock "Test-Clock-2", 1, @ClockId output;