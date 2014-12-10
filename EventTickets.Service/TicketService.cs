using EventTickets.Contracts;
using EventTickets.DataContract;
using EventTickets.Model;
using EventTickets.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;


namespace EventTickets.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TicketService : ITicketService
    {
        private IEventRepository _eventRepository;

        public TicketService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public TicketService()
            : this(new SQLRepository())
        {

        }

        private static MessageResponseHistory<PurchaseTicketResponse> _reservationResponse = new MessageResponseHistory<PurchaseTicketResponse>();
        public DataContract.ReserveTicketResponse ReserveTicket(DataContract.ReserveTicketRequest reserveTicketRequest)
        {
            foreach (Event x in _eventRepository)
                Debug.Print(x.Id.ToString());

            ReserveTicketResponse response = new ReserveTicketResponse();

            try
            {
                Event Event = _eventRepository.FindBy(
                    new Guid(reserveTicketRequest.EventId));
                TicketReservation reservation;

                if(Event.CanReserveTicket(reserveTicketRequest.TicketQuantity))
                {
                    reservation = Event.ReserveTicket(reserveTicketRequest.TicketQuantity);
                    _eventRepository.Save(Event);
                    response = reservation.ConvertToReserveTicketResponse();
                    response.Success = true;

                }
                else
                {
                    response.Success = false;
                    response.Message = String.Format("There are {0} tickets available ", Event.AvailableAllocation());
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
            }
            return response;
        }

        public DataContract.PurchaseTicketResponse PurchaseTicket(DataContract.PurchaseTicketRequest purchaseTicketRequest)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();

            try
            {
                if(_reservationResponse.IsUniqueRequest(purchaseTicketRequest.EventId))
                {
                    TicketPurchase ticket;
                    Event Event = _eventRepository.FindBy(new Guid(purchaseTicketRequest.EventId));

                    if(Event.CanPurchaseTicketWith(new Guid(purchaseTicketRequest.ReservationId)))
                    {
                        ticket = Event.PurchaseTicketWith(new Guid(purchaseTicketRequest.ReservationId));
                        _eventRepository.Save(Event);

                        response = ticket.ConvertToPurchaseTicketResponse();
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = Event.DetermineWhyTicketCannotBePurchasedWith(new Guid(purchaseTicketRequest.ReservationId));
                        response.Success = false;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = String.Format("There is no reservation for {0}", purchaseTicketRequest.ReservationId);
                }
            }
            catch(Exception ex)
            {
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }

            return response;

        }
    }
}
