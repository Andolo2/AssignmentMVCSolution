using AssignmentMVC.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Models.Entities
{

    [PrimaryKey(nameof(UserId), nameof(Adressid))]
    public class UserAdressEntity
    {
        public string UserId { get; set; } = null!;

        public AppUser User { get; set; } = null!;

        public int Adressid { get; set; }

        public AdressEntity Adress { get; set; } = null!;

      
    }
}
