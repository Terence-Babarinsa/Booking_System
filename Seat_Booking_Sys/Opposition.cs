using System;
using System.Collections.Generic;

namespace Seat_Booking_Sys
{
    public partial class Opposition
    {
        public Opposition()
        {
            GameSeats = new HashSet<GameSeats>();
        }

        public int GameId { get; set; }
        public string Opposition1 { get; set; }

        public virtual ICollection<GameSeats> GameSeats { get; set; }
    }
}
