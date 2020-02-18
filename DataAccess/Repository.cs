using System;
using System.Collections.Generic;
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

        public IEnumerable<User> GetUsers()
        {
            string query = @"SELECT id, initials, [name] FROM [user]";
            return _connectionHelper.Query<User>(query);
        }

        public User GetSpecificUser(long id)
        {
            string query = @"SELECT id, initials, [name] FROM [user] WHERE id = @id";
            return _connectionHelper.QueryFirstOrDefault<User>(query, new { id });
        }

        public void AddUser(User newUser)
        {
            string query = "INSERT INTO [user] (initials, [name]) VALUES (@initials, @name)";
            _connectionHelper.Execute(query, newUser);
        }

        public void UpdateUser(User newUser)
        {
            string query = @"UPDATE [user]
                            SET initials = @initials, 
                                [name] = @name
                            WHERE id = @id";
            _connectionHelper.Execute(query, newUser);
        }

        public void DeleteUser(long id)
        {
            string query = "DELETE FROM [user] WHERE id = @id";
            _connectionHelper.Execute(query, new{id});
        }
    }
}
