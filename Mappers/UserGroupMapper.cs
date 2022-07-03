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
    public class UserGroupMapper
    {
        private ApplicationDbContext Context;
        private UserGroupService userGroupService;
        private AccessRuleService accessRuleService;
        public UserGroupMapper(ApplicationDbContext context)
        {
            Context = context;
            userGroupService = new UserGroupService(Context);
            accessRuleService = new AccessRuleService(Context);
        }
        public UserGroupDTO ToUserGroupDTO(UserGroup userGroup)
        {
            UserGroupDTO dto = new UserGroupDTO();
            dto.Id = userGroup.Id;
            dto.GroupName = userGroup.GroupName;
            if (userGroup.AccessRule == null)
                userGroup.AccessRule = accessRuleService.GetAccessRule(userGroup.AccessRuleId);
            dto.AccessRuleDTO = new AccessRuleMapper(Context).ToAccessRuleDTO(userGroup.AccessRule);
            dto.AccessRuleId = userGroup.AccessRuleId;
            return dto;
        }

        public UserGroup ToUserGroup(UserGroupDTO dto)
        {
            UserGroup userGroup = null;
            userGroup = userGroupService.GetUserGroup(dto.Id);
            if (userGroup == null)
                userGroup = new UserGroup();
            userGroup.Id = dto.Id;
            userGroup.AccessRuleId = dto.AccessRuleId;
            userGroup.GroupName = dto.GroupName;
            return userGroup;
        }
    }
}
