using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Mappers;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class AdminService : AbstractService
    {
        public AdminService(ApplicationDbContext context) : base(context)
        {

        }

        public Admin GetAdmin(int adminId) => Context.Admins.FirstOrDefault(e => e.Id == adminId);
        public List<AdminDTO> GetAdmins()
        {
            List<AdminDTO> stdList = new List<AdminDTO>();
            List<Admin> adminList = Context.Admins.ToList();
            foreach (Admin emp in adminList)
            {
                AdminDTO std = new AdminMapper(Context).ToAdminDTO(emp);
                stdList.Add(std);
            }
            return stdList;
        }
    }
}
