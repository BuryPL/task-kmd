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
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        [HttpGet("GetUser/{id}")]
        //[Route("GetUser/")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            return await _repo.GetSpecificUser(id);
        }

        [HttpPut]
        [Route("AddUser")]
        public async Task AddUser([FromBody]User newUser)
        {
            await _repo.AddUser(newUser);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task UpdateUser([FromBody]User newUser)
        {
            await _repo.UpdateUser(newUser);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task DeleteUser(int id)
        {
            await _repo.DeleteUser(id);
        }
    }
}
