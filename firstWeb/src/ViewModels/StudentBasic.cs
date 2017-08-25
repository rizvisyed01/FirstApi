using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StudentBasic
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Achternaam")]
        public string LastName { get; set; }
    }
}
