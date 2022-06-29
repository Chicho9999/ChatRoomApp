global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using UniversityPlatformApi.Data.Models;

namespace ChatRoom.Data.Models
{
    public class ChatRoomDbContext : DbContext
    {
        public ChatRoomDbContext(DbContextOptions<ChatRoomDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<User>();
            var user = new User()
            {
                Id = 1,
                FirstName = "Lisandro",
                LastName = "Chichi",
                Username = "LisandroAdmin",
                Email = "lisandrochichi@gmail.com",
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            var hashedPassword = passwordHasher.HashPassword(user, "admin123.");
            user.Password = hashedPassword;

            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
