using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserGroup : AbstractEntity
    {
        [MaxLength(30)]
        public string GroupName { get; set; }
        public int AccessRuleId { get; set; }
        [ForeignKey("AccessRuleId")]
        public AccessRule AccessRule { get; set; }
    }
}
