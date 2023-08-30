using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication8.Models.PolicyHolder>? PolicyHolder { get; set; }
        public DbSet<WebApplication8.Models.Assurance>? Assurance { get; set; }
        public object Assurances { get; internal set; }
    }
}