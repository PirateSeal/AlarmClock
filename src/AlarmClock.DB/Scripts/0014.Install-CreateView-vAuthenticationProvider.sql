CREATE VIEW spi.vAuthenticationProvider
AS
    SELECT UserId = u.UserId, ProviderName = 'AlarmClock'
    FROM spi.tUsers u
    WHERE u.UserId <> 0;