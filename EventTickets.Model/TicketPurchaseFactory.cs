using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Model
{
    public class TicketPurchaseFactory
    {
        public static TicketPurchase CreateTicket(Event Event, int tktQty)
        {
            TicketPurchase ticket = new TicketPurchase();
            ticket.Id = Guid.NewGuid();
            ticket.TicketQuantity = tktQty;
            ticket.Event = Event;

            return ticket;
        }
    }
}
