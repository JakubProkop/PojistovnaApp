using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Models
{
    public class Payment
    {
        
        public List<SelectListItem> Payments { get; private set; }

        Payment ()
        {
            Payments = new List<SelectListItem>
            {
                new SelectListItem { Text = "Životní pojištění", Value = "Životní pojištění", Selected = true },
                new SelectListItem { Text = "Úrazové pojištění", Value = "Úrazové pojištění" },
                new SelectListItem { Text = "Pojištění odpovědnosti", Value = "Pojištění odpovědnosti" },
                new SelectListItem { Text = "Pojištění majetku", Value = "Pojištění majetku"}
            };
        }
    }
}
