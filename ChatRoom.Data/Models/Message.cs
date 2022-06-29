using System.ComponentModel.DataAnnotations;

namespace UniversityPlatformApi.Data.Models
{
    public class Message : EntityBase
    {
        public int MessageId { get; set; }

        public int RoomId { get; set; }

        [MaxLength(250)]
        [Required]
        public string Body { get; set; }

    }
}