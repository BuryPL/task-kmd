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
            return _connectionHelper.Query<User>("");
        }

        public User GetSpecificUser(long id)
        {
            return _connectionHelper.QueryFirstOrDefault<User>("", new { id });
        }

        public void AddUser(User newUser)
        {
            _connectionHelper.Execute("", newUser);
        }

        public void UpdateUser(User newUser)
        {
            _connectionHelper.Execute("", newUser);
        }

        public void DeleteUser(long id)
        {
            _connectionHelper.Execute("", new{id});
        }
    }
}
