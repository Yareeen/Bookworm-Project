using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Models
{
    public class Reader : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public int CellPhone { get; set; }

        //tabloda göstermez.
        [NotMapped]
        public string Role { get; set; }
    }

}
