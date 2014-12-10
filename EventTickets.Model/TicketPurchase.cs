using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EventTickets.Model
{
    public class TicketPurchase
    {
        [Key]
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public int TicketQuantity { get; set; }
    }
}
