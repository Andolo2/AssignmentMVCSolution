using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;

namespace AssignmentMVC.Repositories
{
    public class AddressRepository : Repository<AdressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
