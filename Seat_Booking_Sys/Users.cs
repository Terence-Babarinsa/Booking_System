using System;
using System.Collections.Generic;

namespace Seat_Booking_Sys
{
    public partial class Users
    {
        public Users()
        {
            GameSeats = new HashSet<GameSeats>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<GameSeats> GameSeats { get; set; }
    }
}
