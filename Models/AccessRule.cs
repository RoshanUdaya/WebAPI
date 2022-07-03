using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AccessRule : AbstractEntity
    {
        [MaxLength(50)]
        public string RuleName { get; set; }
        public bool Permission { get; set; }
        //[ForeignKey("AccessRuleId")]
        //public List<UserGroup> UserGroups { get; set; }

        public void getUserNameList(bool permission)
        {
            //List<string> names = new List<string>();
            //foreach (var group in UserGroups.Where(i => i.AccessRule.Permission == permission))
            //{
            //    names.AddRange(group.Users.ConvertAll(u => u.FirstName));
            //}
        }
    }
}
