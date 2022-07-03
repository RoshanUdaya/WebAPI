using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Person : AbstractEntity
    {
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }

        public string getFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
