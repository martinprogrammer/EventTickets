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
        public DbSet<Event> Events;
    }
}
