using EventTickets.DataContract;
using EventTickets.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventTickets.WCF;
using EventTickets.ServiceProxy;
using System.ServiceModel;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
           EventTickets.Contracts.ITicketService myService;

            myService = new TicketServiceClientProxy();
            //EventTickets.Service.TicketService myService = new TicketService();
            //IEventRepository myRepository = new InMemoryRepository();

            //foreach (Event x in myRepository)
            //    Debug.Print(x.Id.ToString());


            ReserveTicketResponse reservation = myService.ReserveTicket(new ReserveTicketRequest
            {
                EventId = "7632ef29-64aa-4fc7-90aa-d86cf735f1a8",
                TicketQuantity = 3
            });

            Console.WriteLine(reservation.Message ?? "OK");
            Console.WriteLine("{0} {1}", reservation.ReservationNumber, reservation.NoOfTickets);

            PurchaseTicketResponse purchase = myService.PurchaseTicket(new PurchaseTicketRequest
            {
              ReservationId = reservation.ReservationNumber,
              EventId = reservation.EventId,
              
            });

            Console.WriteLine("{0} {1}", purchase.Message ?? "OK", purchase.TicketId);

            Console.Read();
        }
    }
}
