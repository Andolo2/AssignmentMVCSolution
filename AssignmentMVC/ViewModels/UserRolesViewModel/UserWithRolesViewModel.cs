using AssignmentMVC.Models.Identity;

namespace AssignmentMVC.ViewModels.UserRolesViewModel
{
    public class UserWithRolesViewModel
    {
        public AppUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
