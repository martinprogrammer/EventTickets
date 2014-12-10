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
            //Database.SetInitializer(new ContextSQLInitialiser());
            //this._context.Database.Initialize(true);
            //var x = _context.TicketPurchases.Count();
        }

        public SQLRepository()
        {
            _context = new ContextSQL();
            //Database.SetInitializer(new ContextSQLInitialiser());
            //this._context.Database.Initialize(true);
            //var x = _context.TicketPurchases.Count();
            
        }

        public Event FindBy(Guid id)
        {
            var x = _context.Events.SingleOrDefault(p=>p.Id==id);
            return x;
        }

        public void Save(Event eventEntity)
        {
            //_context.Events.Add(eventEntity);
            _context.Entry(eventEntity).State= EntityState.Modified;
            _context.SaveChanges();
        }


        public System.Collections.IEnumerator GetEnumerator()
        {
            return _context.Events.AsEnumerable().GetEnumerator();
        }
    }
}
