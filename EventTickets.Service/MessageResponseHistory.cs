using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Service
{
    public class MessageResponseHistory<T>
    {
        private Dictionary<string, T> _responseHistory;

        public MessageResponseHistory()
        {
            _responseHistory = new Dictionary<string, T>();
        }

        public bool IsUniqueRequest(string correlationId)
        {
            return !_responseHistory.ContainsKey(correlationId);
        }
    }
}
