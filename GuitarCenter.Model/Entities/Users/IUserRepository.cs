using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.Model.Entities.Users
{
    public interface IUserRepository
    {
        List<User> ReadAll();
        void Update(User entity);
        void Create(User entity);
        void Delete(Guid id);
    }
}