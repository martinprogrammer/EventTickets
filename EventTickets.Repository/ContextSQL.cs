using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using EventTickets.Model;

namespace EventTickets.Repository
{
    public class ContextSQL : DbContext
    {
        public ContextSQL()
        {
            Database.SetInitializer(new ContextSQLInitialiser());
            Database.Initialize(true);
           

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketReservation> TicketReservations { get; set; }
        public DbSet<TicketPurchase> TicketPurchases { get; set; }
    }
}
