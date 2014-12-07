using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketResponse : Response
    {
        [DataMember]
        public string TicketId { get; set; }

        [DataMember]
        public string EventName { get; set; }

        [DataMember]
        public string EventId { get; set; }

        [DataMember]
        public int NoOfTickets { get; set; }
    }
}
