using EventTickets.DataContract;
using EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Service
{
    public static class TicketReservationExtensionMethods
    {
        public static ReserveTicketResponse ConvertToReserveTicketResponse(this TicketReservation reservation)
        {
            ReserveTicketResponse response = new ReserveTicketResponse();

            response.EventId = reservation.Event.Id.ToString();
            response.EventName = reservation.Event.Name;
            response.ExpirationDate = reservation.ExpiryTime;
            response.NoOfTickets = reservation.TicketQuantity;
            response.ReservationNumber = reservation.Id.ToString();

            return response;
        }
    }
}
