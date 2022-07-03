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
    public class UserService : AbstractService
    {
        public UserService(ApplicationDbContext context) : base(context)
        {

        }
        public User GetUser(int userId) => Context.Users.FirstOrDefault(e => e.Id == userId);
        public List<UserDTO> GetUsers()
        {
            List<UserDTO> stdList = new List<UserDTO>();
            List<User> userList = Context.Users.Include(user => user.UserGroup).ToList();
            foreach (User emp in userList)
            {
                UserDTO std = new UserMapper(Context).ToUserDTO(emp);
                stdList.Add(std);
            }
            return stdList;
        }
    }
}
