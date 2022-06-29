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

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var identityPasswordHasher = new PasswordHasher<IdentityUser>();

            var userTest = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@test.com",
                UserName = "test",
                NormalizedEmail = "test@test.com",
                NormalizedUserName = "test"
                
            };

            var userAdmin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@admin.com",
                UserName = "admin",
                NormalizedEmail = "admin@admin.com",
                NormalizedUserName = "admin"
            };

            //add rooms
            var roomGames = new Room
            {
                Id = 1,
                Name = "Games",
                CreatedDate = DateTime.Now,
                CreatedBy = 1
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

            var identityTestPassword = identityPasswordHasher.HashPassword(userTest, "test123.");
            var adminPassword = identityPasswordHasher.HashPassword(userAdmin, "admin123.");

            userTest.PasswordHash = identityTestPassword;
            userAdmin.PasswordHash = adminPassword;

            modelBuilder.Entity<Room>().HasData(roomGames);
            modelBuilder.Entity<Room>().HasData(roomPolitics);
            modelBuilder.Entity<Room>().HasData(roomReligion);
            modelBuilder.Entity<IdentityUser>().HasData(userTest);
            modelBuilder.Entity<IdentityUser>().HasData(userAdmin);
        }
    }
}
