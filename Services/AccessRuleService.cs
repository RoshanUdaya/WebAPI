using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Mappers;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Services;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class AccessRuleService : AbstractService
    {
        public AccessRuleService(ApplicationDbContext context) : base(context)
        {

        }
        public AccessRule GetAccessRule(int accessRuleId) => Context.AccessRules.FirstOrDefault(e => e.Id == accessRuleId);
        public List<AccessRuleDTO> GetAccessRules()
        {
            List<AccessRuleDTO> stdList = new List<AccessRuleDTO>();
            List<AccessRule> accessRuleList = Context.AccessRules.ToList();
            foreach (AccessRule emp in accessRuleList)
            {
                AccessRuleDTO std = new AccessRuleMapper(Context).ToAccessRuleDTO(emp);
                stdList.Add(std);
            }
            return stdList;
        }
    }
}
