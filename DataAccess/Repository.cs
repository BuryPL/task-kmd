using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private readonly IConnectionHelper _connectionHelper;

        public Repository(IConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper ?? throw new ArgumentNullException(nameof(connectionHelper));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            string query = @"SELECT id, initials, [name] FROM [user]";
            return await _connectionHelper.QueryAsync<User>(query);
        }

        public async Task<User> GetSpecificUser(long id)
        {
            string query = @"SELECT id, initials, [name] FROM [user] WHERE id = @id";
            return await _connectionHelper.QueryFirstOrDefaultAsync<User>(query, new { id });
        }

        public async Task<long> AddUser(User newUser)
        {
            string query = @"INSERT INTO [user] (initials, [name]) 
                            OUTPUT INSERTED.[id]
                            VALUES (@initials, @name)";
            return await _connectionHelper.ExecuteRetAsync(query, newUser);
        }

        public async Task<int> UpdateUser(User newUser)
        {
            string query = @"UPDATE [user]
                            SET initials = @initials, 
                                [name] = @name
                            WHERE id = @id";
            return await _connectionHelper.ExecuteRetAsync(query, newUser);
        }

        public async Task<int> DeleteUser(long id)
        {
            string query = "DELETE FROM [user] WHERE id = @id";
            return await _connectionHelper.ExecuteRetAsync(query, new{id});
        }
    }
}
