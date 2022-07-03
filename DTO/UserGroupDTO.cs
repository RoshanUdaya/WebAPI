using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UserGroupDTO : AbstractEntityDTO
    {
        public string GroupName { get; set; }
        public AccessRuleDTO AccessRuleDTO { get; set; }
        public int AccessRuleId { get; set; }
    }
}
