using System;
using System.Collections.Generic;
using System.Data;
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
    public class AdminsController : ControllerBase
    {
        private AdminService adminService;
        private readonly ILogger<AdminsController> _logger;
        private AdminMapper adminMapper;
        public AdminsController(ApplicationDbContext context, ILogger<AdminsController> logger)
        {
            adminService = new AdminService(context);
            adminMapper = new AdminMapper(context);
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdminDTO adminDTO)
        {
            try
            {
                Admin admin = adminMapper.ToAdmin(adminDTO);
                adminService.InsertEntity(admin);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Save Admin", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] AdminDTO adminDTO)
        {
            try
            {
                Admin admin = adminMapper.ToAdmin(adminDTO);
                adminService.UpdateEntity(admin);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update Admin", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AdminDTO> admins = adminService.GetAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{adminId}")]
        public IActionResult Delete(int adminId)
        {
            try
            {
                Admin admin = adminService.GetAdmin(adminId);
                adminService.DeleteEntity(admin);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Delete Admin", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
