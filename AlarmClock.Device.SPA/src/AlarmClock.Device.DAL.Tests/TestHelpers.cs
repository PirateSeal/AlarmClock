using System;

namespace AlarmClock.Device.DAL.Tests
{
    public static class TestHelpers
    {
        public static Random Random { get; } = new Random();

        public static string RandomTestName()
        {
            return $"Test-{Guid.NewGuid().ToString().Substring( 24 )}";
        }

        public static DateTime RandomBirthDate( int age )
        {
            return DateTime.UtcNow.AddYears( -age ).AddMonths( Random.Next( -11, 0 ) ).Date;
        }

        public static string RandomLevel()
        {
            int levelIdx = Random.Next( 5 );
            if( levelIdx == 0 ) return "CP";
            if( levelIdx == 1 ) return "CE1";
            if( levelIdx == 2 ) return "CE2";
            if( levelIdx == 3 ) return "CM1";
            return "CM2";
        }
    }
}
