using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseBankExchange.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }
    }
}
