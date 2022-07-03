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
    public class UserMapper
    {
        private ApplicationDbContext Context;
        private UserService userService;
        public UserMapper(ApplicationDbContext context)
        {
            Context = context;
            userService = new UserService(Context);
        }

        public UserDTO ToUserDTO(User user)
        {
            UserDTO dto = new UserDTO();
            dto.Id = user.Id;
            dto.AttachedCustomerId = user.AttachedCustomerId;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.Email = user.Email;
            dto.UserGroupDTO = new UserGroupMapper(Context).ToUserGroupDTO(user.UserGroup);
            dto.UserGroupId = user.UserGroupId;
            return dto;
        }

        public User ToUser(UserDTO dto)
        {
            User user = null;
            user = userService.GetUser(dto.Id);
            if (user == null)
                user = new User();
            user.Id = dto.Id;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.AttachedCustomerId = dto.AttachedCustomerId;
            user.UserGroupId = dto.UserGroupId;
            return user;
        }
    }
}
