using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Models
{
    public class CommantBook
    {
        [Key]
        public int ID { get; set; }

        public int Book_ID { get; set; }

        public string Reader_ID { get; set; }
        public string comment { get; set; }

        public DateTime CommantTime { get; set; }

        [ForeignKey("Book_ID")]
        public Book Book { get; set; }

        [ForeignKey("Reader_ID")]
        public Reader Reader { get; set; }
    }
}
