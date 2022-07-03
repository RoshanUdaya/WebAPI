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
    public class UserGroupsController : ControllerBase
    {
        private UserGroupService userGroupService;
        private readonly ILogger<UserGroupsController> _logger;
        private UserGroupMapper userGroupMapper;
        public UserGroupsController(ApplicationDbContext context, ILogger<UserGroupsController> logger)
        {
            userGroupService = new UserGroupService(context);
            userGroupMapper = new UserGroupMapper(context);
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserGroupDTO userGroupDTO)
        {
            try
            {
                UserGroup userGroup = userGroupMapper.ToUserGroup(userGroupDTO);
                userGroupService.InsertEntity(userGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Save UserGroup", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserGroupDTO userGroupDTO)
        {
            try
            {
                UserGroup userGroup = userGroupMapper.ToUserGroup(userGroupDTO);
                userGroupService.UpdateEntity(userGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update UserGroup", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<UserGroupDTO> userGroups = userGroupService.GetUserGroups();
                return Ok(userGroups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userGroupId}")]
        public IActionResult Delete(int userGroupId)
        {
            try
            {
                UserGroup userGroup = userGroupService.GetUserGroup(userGroupId);
                userGroupService.DeleteEntity(userGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Delete UserGroup", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
