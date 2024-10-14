using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PulpTicket.Domain.Repositories
{
    internal interface IUserRepository<User>
    {
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        void Add(User entity);
        void Update(User entity);
        void Delete(Guid id);
       
    }
}
}
