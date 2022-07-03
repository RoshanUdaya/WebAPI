using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UserDTO : PersonDTO
    {
        public int AttachedCustomerId { get; set; }
        public UserGroupDTO UserGroupDTO { get; set; }
        public int UserGroupId { get; set; }
    }
}
