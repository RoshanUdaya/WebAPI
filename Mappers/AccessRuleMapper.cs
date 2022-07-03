using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Mappers
{
    public class AccessRuleMapper
    {
        private ApplicationDbContext Context;
        private AccessRuleService accessRuleService;
        public AccessRuleMapper(ApplicationDbContext context)
        {
            Context = context;
            accessRuleService = new AccessRuleService(Context);
        }
        public AccessRuleDTO ToAccessRuleDTO(AccessRule accessRule)
        {
            AccessRuleDTO dto = new AccessRuleDTO();
            dto.Id = accessRule.Id;
            dto.Permission = accessRule.Permission;
            dto.RuleName = accessRule.RuleName;
            return dto;
        }

        public AccessRule ToAccessRule(AccessRuleDTO dto)
        {
            AccessRule accessRule = null;
            accessRule = accessRuleService.GetAccessRule(dto.Id);
            if (accessRule == null)
                accessRule = new AccessRule();
            accessRule.Id = dto.Id;
            accessRule.Permission = dto.Permission;
            accessRule.RuleName = dto.RuleName;
            return accessRule;
        }
    }
}
