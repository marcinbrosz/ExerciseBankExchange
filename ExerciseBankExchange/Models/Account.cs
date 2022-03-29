using System.ComponentModel.DataAnnotations;

namespace ExerciseBankExchange.Models
{
    public class Account
    {
        public int Id { get; set; }
        public User User { get; set; }
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        public float SaldoPl { get; set; }
    }
}
