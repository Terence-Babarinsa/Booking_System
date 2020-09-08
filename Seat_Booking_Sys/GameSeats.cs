using System;
using System.Collections.Generic;

namespace Seat_Booking_Sys
{
    public partial class GameSeats
    {
        public int GameSeatsId { get; set; }
        public int SeatId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }

        public virtual Opposition Game { get; set; }
        public virtual Seating Seat { get; set; }
        public virtual Users User { get; set; }
    }
}
