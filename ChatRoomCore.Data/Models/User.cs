using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityPlatformApi.Data.Models
{
    public class User : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string? LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Username { get; set; }

        [MaxLength(30)]
        [Required]
        public string? Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string? Password { get; set; }
    }
}