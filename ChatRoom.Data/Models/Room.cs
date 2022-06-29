using System.ComponentModel.DataAnnotations;

namespace UniversityPlatformApi.Data.Models
{
    public class Room : EntityBase
    {
        public int RoomId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

    }
}