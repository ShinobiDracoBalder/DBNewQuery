using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PartialViewCrudDemo.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCustomers();
    }
}
