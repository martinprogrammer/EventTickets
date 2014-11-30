using EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTickets.Repository
{
    public class RepositoryFactory
    {
        

        public static IEventRepository GetRepository(RepositoryType repositoryType)
        {
           

            switch (repositoryType)
            {
                case RepositoryType.InMemoryRepository :
                    return  new InMemoryRepository();
                case RepositoryType.SQLRepository :
                    return new SQLRepository();
                default:
                    return new InMemoryRepository();
            }

           
        }
    }
}
