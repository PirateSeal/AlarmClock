using System;
using System.ComponentModel.DataAnnotations;

namespace AlarmClock.WebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display( Name = "Email" )]
        public string Email { get; set; }

        [Required]
        [StringLength( 30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3 )]
        [Display( Name = "Pseudo" )]
        public string Pseudo { get; set; }

        [Required]
        [StringLength( 100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6 )]
        [DataType( DataType.Password )]
        [Display( Name = "Password" )]
        public string Password { get; set; }

        [DataType( DataType.Password )]
        [Display( Name = "Confirm password" )]
        [Compare( "Password", ErrorMessage = "The password and confirmation password do not match." )]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength( 30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3 )]
        [Display( Name = "FirstName" )]
        public string FirstName { get; set; }

        [Required]
        [StringLength( 30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3 )]
        [Display( Name = "LastName" )]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "BirthDate")]
        public  DateTime BirthDate { get; set; }
    }
}
