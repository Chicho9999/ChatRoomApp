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

            //add Users
            var lisandro = new User()
            {
                Id = 1,
                FirstName = "Lisandro",
                LastName = "Chichi",
                Username = "LisandroAdmin",
                Email = "lisandrochichi@gmail.com",
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            var test = new User()
            {
                Id = 2,
                FirstName = "Test",
                LastName = "Test",
                Username = "TestAdmin",
                Email = "test@gmail.com",
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            //add rooms
            var roomGames = new Room { 
                Id = 1,
                Name = "Games",
                CreatedDate= DateTime.Now,
                CreatedBy= 1
            };

            var roomPolitics = new Room
            {
                Id = 2,
                Name = "Politics",
                CreatedDate = DateTime.Now,
                CreatedBy = 1
            };

            var roomReligion = new Room
            {
                Id = 3,
                Name = "Religion",
                CreatedDate = DateTime.Now,
                CreatedBy = 1
            };

            var hashedPassword = passwordHasher.HashPassword(lisandro, "admin123.");
            var testPassword = passwordHasher.HashPassword(test, "test123.");

            lisandro.Password = hashedPassword;
            test.Password = testPassword;

            modelBuilder.Entity<User>().HasData(lisandro);
            modelBuilder.Entity<User>().HasData(test);
            modelBuilder.Entity<Room>().HasData(roomGames);
            modelBuilder.Entity<Room>().HasData(roomPolitics);
            modelBuilder.Entity<Room>().HasData(roomReligion);
        }
    }
}
