using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class AccessRuleDTO : AbstractEntityDTO
    {
        public string RuleName { get; set; }
        public bool Permission { get; set; }
    }
}
