using EventTickets.DataContract;
using EventTickets.Model;
using EventTickets.Repository;
using EventTickets.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EventTickets.Service.TicketService myService = new TicketService();
            //IEventRepository myRepository = new InMemoryRepository();

            //foreach (Event x in myRepository)
            //    Debug.Print(x.Id.ToString());


            ReserveTicketResponse reservation = myService.ReserveTicket(new ReserveTicketRequest
            {
                EventId = "6e79136c-c96a-496b-96fb-5e7d20e0cb31",
                TicketQuantity = 3
            });

            Console.WriteLine(reservation.Message ?? "OK");
            Console.WriteLine("{0} {1}", reservation.ReservationNumber, reservation.NoOfTickets);

            PurchaseTicketResponse purchase = myService.PurchaseTicket(new PurchaseTicketRequest
            {
              ReservationId = reservation.ReservationNumber
            });

            Console.WriteLine("{0} {1}", purchase.Message ?? "OK", purchase.TicketId);

            Console.Read();
        }
    }
}
