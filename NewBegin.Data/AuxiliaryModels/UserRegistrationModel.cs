using System.ComponentModel.DataAnnotations;

namespace NewBegin.Data.AuxiliaryModels
{
    public class UserRegistrationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CountryAlpha3Code { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
