using Microsoft.AspNetCore.Identity;

namespace todolist.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Aka { get; set; } = "Muichiro96";
        public virtual ICollection<Todos>? taches { get; set; }
    }
}
