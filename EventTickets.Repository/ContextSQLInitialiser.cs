using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventTickets.Model;

namespace EventTickets.Repository
{
    public class ContextSQLInitialiser : DropCreateDatabaseIfModelChanges<ContextSQL>
    {
       protected override void Seed(ContextSQL context)
        {

            context.Events.Add(new Event
            {
                Allocation = 20,
                Id = Guid.NewGuid(),
                Name = "Prince Concert",
                PurchasedTickets = null,
                TicketReservations = null
            });

            context.Events.Add(new Event
            {
                Allocation = 10,
                Id = Guid.NewGuid(),
                Name = "Classic Car Auction",
                PurchasedTickets = null,
                TicketReservations = null
            });

            context.Events.Add(new Event
            {
                Allocation = 17,
                Id = Guid.NewGuid(),
                Name = "Lido Crawl",
                PurchasedTickets = null,
                TicketReservations = null
            });

            context.Events.Add(new Event
            {
                Allocation = 5,
                Id = Guid.NewGuid(),
                Name = "Banana Party",
                PurchasedTickets = null,
                TicketReservations = null
            });


            context.SaveChanges();
        }
    }
}
