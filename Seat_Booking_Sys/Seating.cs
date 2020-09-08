using System;
using System.Collections.Generic;

namespace Seat_Booking_Sys
{
    public partial class Seating
    {
        public Seating()
        {
            GameSeats = new HashSet<GameSeats>();
        }

        public int SeatId { get; set; }
        public string Seat { get; set; }

        public virtual ICollection<GameSeats> GameSeats { get; set; }
    }
}
