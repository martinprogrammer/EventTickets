﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EventTickets.DataContract
{
    [DataContract]
    public class PurchaseTicketRequest
    {
        [DataMember]
        public string CorrelationId { get; set; }
        
        [DataMember]
        public string ReservationId { get; set; }

        [DataMember]
        public string EventId { get; set; }
    }
}
