using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EventTickets.DataContract;
using EventTickets.WCF;

namespace EventTickets.ServiceProxy
{
    public class TicketServiceClientProxy : ClientBase<EventTickets.Contracts.ITicketService>, EventTickets.Contracts.ITicketService
    {
        
        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {
            return base.Channel.ReserveTicket(reserveTicketRequest);
        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest)
        {
            return base.Channel.PurchaseTicket(purchaseTicketRequest);
        }
    }
}
