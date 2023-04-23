using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;

namespace AssignmentMVC.Repositories
{
    public class UserAddressRepository : Repository<UserAdressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
