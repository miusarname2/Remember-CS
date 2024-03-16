using System.ComponentModel.DataAnnotations;

namespace rememberCs.Models.DataModels
{
    public class UserLoggins
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
