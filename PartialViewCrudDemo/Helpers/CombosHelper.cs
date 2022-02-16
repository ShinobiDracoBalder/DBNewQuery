using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboCustomers()
        {
            List<SelectListItem> countries = new List<SelectListItem>();
            countries.Add(new SelectListItem { Text = "Select", Value = "" });
            countries.Add(new SelectListItem { Text = "USA", Value = "1" });
            countries.Add(new SelectListItem { Text = "India", Value = "2" });
            countries.Add(new SelectListItem { Text = "Russia", Value = "3" });
            countries.Add(new SelectListItem { Text = "France", Value = "4" });

            return countries;
        }
    }
}
