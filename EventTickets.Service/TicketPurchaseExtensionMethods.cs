﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventTickets.DataContract;
using EventTickets.Model;

namespace EventTickets.Service
{
    public static class TicketPurchaseExtensionMethods
    {
        public static PurchaseTicketResponse ConvertToPurchaseTicketResponse(this TicketPurchase ticketPurchase)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();
            response.TicketId = ticketPurchase.Id.ToString();
            response.EventName = ticketPurchase.Event.Name;
            response.EventId = ticketPurchase.Event.Id.ToString();
            response.NoOfTickets = ticketPurchase.TicketQuantity;

            return response;

        }
    }
}
