using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP101K.Entities;
using SP101K.Repo;
using System;
using System.Collections.Generic;

namespace SP101K.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly userRepo<User> _userRepo;
        public UsersController(userRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _userRepo.Users();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "getUser")]
        public IActionResult Get(int id)
        {

            try
            {
                User user = _userRepo.getUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
 
        [HttpPost]
        public IActionResult Post([FromBody] User data)
        {
            try
            {
                _userRepo.addUser(data);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User data)
        {
            try
            {
                User user = _userRepo.getUser(data.Id);
                if(user != null)
                {
                    _userRepo.updateUser(user,data);
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                User user = _userRepo.getUser(id);
                if (user != null)
                {
                    _userRepo.deleteUser(user);
                    return Ok();
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
