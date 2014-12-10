using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Model
{
    public class TicketReservation
    {
        [Key]
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public DateTime ExpiryTime { get; set; }
        public int TicketQuantity { get; set; }
        public bool HasBeenRedeemed { get; set; }

        public bool HasExpired()
        {
            return DateTime.Now > ExpiryTime;
        }

        public bool StillActive()
        {
            return !HasBeenRedeemed & !HasExpired();
        }
    }
}
