using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Detail { get; set; }
        public string Picture { get; set; }
        public string Writer { get; set; }
        public int Category_ID { get; set; }


        [ForeignKey("Category_ID")]
        public Category Category { get; set; }
    }
}
