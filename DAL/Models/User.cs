using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get; set; }
       
        public string LastName { get; set; }
      
    }
}
