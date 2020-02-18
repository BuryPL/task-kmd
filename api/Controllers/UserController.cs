using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;
        public UserController(IRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _repo.GetUsers();
        }

        [HttpGet("GetUser/{id}")]
        //[Route("GetUser/")]
        public ActionResult<User> GetUser(long id)
        {
            return _repo.GetSpecificUser(id);
        }

        [HttpPut]
        [Route("AddUser")]
        public void AddUser([FromBody]User newUser)
        {
            _repo.AddUser(newUser);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public void UpdateUser([FromBody]User newUser)
        {
            _repo.UpdateUser(newUser);
        }

        [HttpDelete("DeleteUser/{id}")]
        public void DeleteUser(int id)
        {
            _repo.DeleteUser(id);
        }
    }
}
