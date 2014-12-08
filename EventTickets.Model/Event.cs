using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventTickets.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Allocation { get; set; }
        public List<TicketReservation> TicketReservations { get; set; }
        public List<TicketPurchase> PurchasedTickets { get; set; }
        public Event()
        {
            TicketReservations = new List<TicketReservation>();
            PurchasedTickets = new List<TicketPurchase>();
        }

        public int AvailableAllocation()
        {
            int salesAndReservations = 0;

            PurchasedTickets.ForEach(p => salesAndReservations += p.TicketQuantity);
            TicketReservations.ForEach(p => salesAndReservations += p.TicketQuantity);
            return Allocation - salesAndReservations;
            
        }

        public bool CanPurchaseTicketWith(Guid reservationId)
        {
            
                return GetReservationWith(reservationId).StillActive();
        }

        public TicketPurchase PurchaseTicketWith(Guid reservationId)
        {
            if (!CanPurchaseTicketWith(reservationId))
                throw new ApplicationException(DetermineWhyTicketCannotBePurchasedWith(reservationId));

            TicketReservation reservation = GetReservationWith(reservationId);
            TicketPurchase ticket = TicketPurchaseFactory.CreateTicket(this, reservation.TicketQuantity);

            reservation.HasBeenRedeemed = true;

            PurchasedTickets.Add(ticket);

            return ticket;
        }

        public TicketReservation GetReservationWith(Guid reservationId)
        {
            if (!HasReservationWith(reservationId))
                throw new ApplicationException(String.Format("No reservation ticket with matching id of {0}", reservationId.ToString()));

            return TicketReservations.FirstOrDefault(p => p.Id == reservationId);


        }

        private bool HasReservationWith(Guid reservationId)
        {
            return TicketReservations.Any(p => p.Id == reservationId);
              
        }

        public string DetermineWhyTicketCannotBePurchasedWith(Guid reservationId)
        {
            string reservationIssue = "";
            if(HasReservationWith(reservationId))
            {
                TicketReservation reservation = GetReservationWith(reservationId);;
                if(reservation.HasExpired())
                    reservationIssue = String.Format("Ticket reservation no {0} has expired", reservationId);
                else if(reservation.HasBeenRedeemed)
                    reservationIssue = String.Format("Ticket reservation no {0} has been redeemed", reservationId);
                
            }
            else
                reservationIssue = String.Format("Ticket reservation no {0} doesn't exist", reservationId);

            return reservationIssue;
        }

        private void ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved()
        {
            throw new ApplicationException("There are no tickets available to reserve");
        }

        public bool CanReserveTicket(int qty)
        {
            return AvailableAllocation() >= qty;
        }

        public TicketReservation ReserveTicket(int tktQty)
        {
            if (!CanReserveTicket(tktQty))
                ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved();
          
                TicketReservation reservation = TicketReservationFactory.CreateReservation(this, tktQty);
                TicketReservations.Add(reservation);
                return reservation;
       
            
        }    



        }
    }

