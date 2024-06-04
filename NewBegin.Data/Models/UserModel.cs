using System.ComponentModel.DataAnnotations;

namespace NewBegin.Data.Models
{
    public class UserModel
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
