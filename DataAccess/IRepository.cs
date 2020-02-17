using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers();
        User GetSpecificUser(long id);
        void AddUser(User newUser);
        void UpdateUser(User newUser);
        void DeleteUser(long id);
    }
}