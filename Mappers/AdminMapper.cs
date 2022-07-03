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
    public class AdminMapper
    {
        private ApplicationDbContext Context;
        private AdminService adminService;
        public AdminMapper(ApplicationDbContext context)
        {
            Context = context;
            adminService = new AdminService(Context);
        }

        public AdminDTO ToAdminDTO(Admin admin)
        {
            AdminDTO dto = new AdminDTO();
            dto.Id = admin.Id;
            dto.FirstName = admin.FirstName;
            dto.LastName = admin.LastName;
            dto.Email = admin.Email;
            dto.Privilege = admin.Privilege;
            return dto;
        }

        public Admin ToAdmin(AdminDTO dto)
        {
            Admin admin = null;
            admin = adminService.GetAdmin(dto.Id);
            if (admin == null)
                admin = new Admin();
            admin.Id = dto.Id;
            admin.FirstName = dto.FirstName;
            admin.LastName = dto.LastName;
            admin.Email = dto.Email;
            admin.Privilege = dto.Privilege;
            return admin;
        }
    }
}
