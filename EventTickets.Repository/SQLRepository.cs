using EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Repository
{
    public class SQLRepository : IEventRepository
    {
        private ContextSQL _context;

        public SQLRepository(ContextSQL context)
        {
            _context = context;
            Database.SetInitializer<ContextSQL>(new ContextSQLInitialiser());
        }

        public SQLRepository()
        {
            _context = new ContextSQL();
        }

        public Event FindBy(Guid id)
        {
            return _context.Events.Single(p=>p.Id==id);
        }

        public void Save(Event eventEntity)
        {
            _context.Events.Add(eventEntity);
            _context.SaveChanges();
        }


        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
