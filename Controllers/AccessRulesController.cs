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
    public class AccessRulesController : ControllerBase
    {
        private AccessRuleService accessRuleService;
        private readonly ILogger<AccessRulesController> _logger;
        private AccessRuleMapper accessRuleMapper;
        public AccessRulesController(ApplicationDbContext context, ILogger<AccessRulesController> logger)
        {
            accessRuleService = new AccessRuleService(context);
            accessRuleMapper = new AccessRuleMapper(context);
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccessRuleDTO accessRuleDTO)
        {
            try
            {
                AccessRule accessRule = accessRuleMapper.ToAccessRule(accessRuleDTO);
                accessRuleService.InsertEntity(accessRule);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Save AccessRule", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] AccessRuleDTO accessRuleDTO)
        {
            try
            {
                AccessRule accessRule = accessRuleMapper.ToAccessRule(accessRuleDTO);
                accessRuleService.UpdateEntity(accessRule);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update AccessRule", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AccessRuleDTO> accessRules = accessRuleService.GetAccessRules();
                return Ok(accessRules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accessRuleId}")]
        public IActionResult Delete(int accessRuleId)
        {
            try
            {
                AccessRule accessRule = accessRuleService.GetAccessRule(accessRuleId);
                accessRuleService.DeleteEntity(accessRule);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Delete AccessRule", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
