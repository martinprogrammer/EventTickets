using EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EventTickets.Repository
{
    public class InMemoryRepository : IEventRepository
    {
        private List<Event> Events;

        public InMemoryRepository()
        {
            Events = new List<Event>();
        }

        public Event FindBy(Guid id)
        {
            return Events.SingleOrDefault(p => p.Id == id);
        }

        public void Save(Event eventEntity)
        {
            Events.Add(eventEntity);
        }
    }
}
