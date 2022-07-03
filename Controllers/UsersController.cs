using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Mappers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService userService;
        private readonly ILogger<UsersController> _logger;
        private UserMapper userMapper;
        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger)
        {
            userService = new UserService(context);
            userMapper = new UserMapper(context);
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = userMapper.ToUser(userDTO);
                userService.InsertEntity(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Save User", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = userMapper.ToUser(userDTO);
                userService.UpdateEntity(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update User", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<UserDTO> users = userService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            try
            {
                User user = userService.GetUser(userId);
                userService.DeleteEntity(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Delete User", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
