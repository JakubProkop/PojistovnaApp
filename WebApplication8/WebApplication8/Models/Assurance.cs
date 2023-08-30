using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication8.Models
{
    public class Assurance
    {
        public int Id { get; set; }
        public int PolicyholderId { get; set; }
        [Required]
        public string Type { get; set; } = "";
        public int Amount { get; set; }
        [Required]
        public string Payment { get; set; } = "";
        public virtual PolicyHolder PolicyHolder { get; set; }
    }

}
