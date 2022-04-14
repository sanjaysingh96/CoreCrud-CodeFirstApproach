using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoadFirstWithCore.Models
{
    public class Empmodel
    {
        [Key]
        public int id  { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; } 


    }
}
