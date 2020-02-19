using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetSpecificUser(long id);
        Task<long> AddUser(User newUser);
        Task<int> UpdateUser(User newUser);
        Task<int> DeleteUser(long id);
    }
}