using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Model
{
    public class TicketReservationFactory
    {
        public static TicketReservation CreateReservation(Event Event, int tktQty)
        {
            TicketReservation reservation = new TicketReservation();
            reservation.Id = Guid.NewGuid();
            reservation.TicketQuantity = tktQty;
            reservation.Event = Event;
            reservation.ExpiryTime = DateTime.Now.AddMinutes(1D);

            return reservation;
        }
    }
}
