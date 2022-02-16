using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBNewQuery.Common.Models
{
    public class Customer
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Name Required!")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Country Required!")]
        public string Country { set; get; }
    }
}
