using System.ComponentModel.DataAnnotations;

namespace CryptoAvenue.Dtos.UserDtos
{
    public class UserPutPostDto
    {
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        public string SecurityQuestion { get; set; }

        [Required]
        [MaxLength (30)]
        public string SecurityAnswer { get; set; }

        [Required]
        public bool PrivateProfile { get; set; }
    }
}
