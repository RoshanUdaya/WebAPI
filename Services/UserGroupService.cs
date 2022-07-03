using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Mappers;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserGroupService : AbstractService
    {
        public UserGroupService(ApplicationDbContext context) : base(context)
        {

        }
        public UserGroup GetUserGroup(int userGroupId) => Context.UserGroups.FirstOrDefault(e => e.Id == userGroupId);
        public List<UserGroupDTO> GetUserGroups()
        {
            List<UserGroupDTO> stdList = new List<UserGroupDTO>();
            List<UserGroup> userGroupList = Context.UserGroups.Include(group => group.AccessRule).ToList();
            foreach (UserGroup emp in userGroupList)
            {
                UserGroupDTO std = new UserGroupMapper(Context).ToUserGroupDTO(emp);
                stdList.Add(std);
            }
            return stdList;
        }
    }
}
