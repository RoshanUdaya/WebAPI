using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Admin : Person
    {
        [MaxLength(80)]
        public string Privilege { get; set; }
    }
}
