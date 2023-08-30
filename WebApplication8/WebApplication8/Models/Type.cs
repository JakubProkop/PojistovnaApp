using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication8.Models
{
    public class Type
    {
        public int Id { get; set; }
        public List<SelectListItem> Types { get; private set; }
        public Type()
        {
            Types = new List<SelectListItem>
            {
                new SelectListItem { Text = "Ročně", Value = "Ročně", Selected = true },
                new SelectListItem { Text = "Měsíčně", Value = "Měsíčně" },
               
            };
        }
    }
}
