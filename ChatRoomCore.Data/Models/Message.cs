using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityPlatformApi.Data.Models
{
    public class Message : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoomId { get; set; }

        [MaxLength(250)]
        [Required]
        public string? Body { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }

    }
}