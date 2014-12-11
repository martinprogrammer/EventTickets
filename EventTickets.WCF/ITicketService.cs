using EventTickets.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EventTickets.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITicketService" in both code and config file together.
    [ServiceContract]
    public interface ITicketService
    {
       

  
        [OperationContract]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest);
        [OperationContract]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest);
    }
}


