using System;

namespace AlarmClock.DAL.Data
{
    public class UserData
    {
        public int UserId { get; set; }

        public string Pseudo { get; set; }

        public byte[] HashedPassword { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string UserType { get; set; }
    }
}
