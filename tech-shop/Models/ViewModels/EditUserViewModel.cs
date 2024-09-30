using System.ComponentModel.DataAnnotations;

namespace tech_shop.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Current Roles")]
        public List<string> UserRoles { get; set; }

        [Display(Name = "Available Roles")]
        public List<string> AllRoles { get; set; }

        [Display(Name = "Selected Roles")]
        public List<string> SelectedRoles { get; set; }
    }
}
