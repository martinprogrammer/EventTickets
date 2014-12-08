using EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;

namespace EventTickets.Repository
{
    public class InMemoryRepository : IEventRepository
    {
        private List<Event> Events;

        public InMemoryRepository()
        {
            Events = new List<Event>();
            Seed(Events);


        }

        public Event FindBy(Guid id)
        {
            return Events.SingleOrDefault(p => p.Id == id);
        }

        public void Save(Event eventEntity)
        {
            Events.Add(eventEntity);
        }

        protected void Seed(List<Event> Events)
        {

            Events.Add(new Event
            {
                Allocation = 20,
                Id = new Guid("6e79136c-c96a-496b-96fb-5e7d20e0cb31"),
                Name = "Prince Concert"
            });

            Events.Add(new Event
            {
                Allocation = 10,
                Id = new Guid("d4eec27d-b1cd-47d1-82cb-2d9e14f5c5e7"),
                Name = "Classic Car Auction"
            });

            Events.Add(new Event
            {
                Allocation = 17,
                Id = new Guid("63607b17-284a-410d-bdd9-76d993e516a4"),
                Name = "Lido Crawl"
            });

            Events.Add(new Event
            {
                Allocation = 5,
                Id = new Guid("a7216181-da80-4d19-b4dd-9da746290f5c"),
                Name = "Banana Party"
            });
        }

        public IEnumerator GetEnumerator()
        {
            return Events.GetEnumerator();
        }

        public string this[int itemIndex]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }
    }
}
