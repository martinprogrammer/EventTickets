using EventTickets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Service
{
    public class TicketService : ITicketService
    {
        public DataContract.ReserveTicketResponse ReserveTicket(DataContract.ReserveTicketRequest reserveTicketRequest)
        {
            throw new NotImplementedException();
        }

        public DataContract.PurchaseTicketResponse PurchaseTicket(DataContract.PurchaseTicketRequest purchaseTicketRequest)
        {
            throw new NotImplementedException();
        }
    }
}
