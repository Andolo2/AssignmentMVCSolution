using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AdressEntity> AspNetAdresses { get; set; }
        public DbSet<UserAdressEntity> AspNetUsersAdresses { get; set; }



    }
}
