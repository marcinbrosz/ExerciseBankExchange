using System.ComponentModel.DataAnnotations;

namespace ExerciseBankExchange.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        public float SaldoPl { get; set; }
    }
}
