using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Contexts
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
