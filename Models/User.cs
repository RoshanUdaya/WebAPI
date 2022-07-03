using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User : Person
    {
        public int AttachedCustomerId { get; set; }
        public int UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        public UserGroup UserGroup { get; set; }
    }
}
