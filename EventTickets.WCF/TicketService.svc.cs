using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventTickets.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TicketService.svc or TicketService.svc.cs at the Solution Explorer and start debugging.
    public class TicketService : EventTickets.Contracts.ITicketService
    {

        private EventTickets.Service.TicketService _ticketService;

        public TicketService()
            : this(new EventTickets.Service.TicketService())
        {

        }

        public TicketService(EventTickets.Service.TicketService ticketService)
        {
            _ticketService = ticketService;
        }




        public DataContract.ReserveTicketResponse ReserveTicket(DataContract.ReserveTicketRequest reserveTicketRequest)
        {
            return _ticketService.ReserveTicket(reserveTicketRequest);
        }

        public DataContract.PurchaseTicketResponse PurchaseTicket(DataContract.PurchaseTicketRequest purchaseTicketRequest)
        {
            return _ticketService.PurchaseTicket(purchaseTicketRequest);
        }
    }

}
