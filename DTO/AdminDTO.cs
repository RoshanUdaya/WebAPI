using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class AdminDTO : PersonDTO
    {
        public string Privilege { get; set; }
    }
}
