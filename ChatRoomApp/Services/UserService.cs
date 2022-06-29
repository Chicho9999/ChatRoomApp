using ChatRoom.Data.Models;
using ChatRoomApp.Services.Interface;

namespace ChatRoomApp.Services
{
    public class UserService : IUserService
    {
        public ChatRoomDbContext DbContext;

        public UserService(ChatRoomDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await DbContext.Users.ToListAsync();
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (user == null)
                return null;
            return user;
        }
    }
}
