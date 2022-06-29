using ChatRoom.Data.Models;
using ChatRoomApp.Services.Interface;

namespace ChatRoomApp.Services
{
    public class UserService : IUserService
    {
        public ChatRoomDbContext _dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public UserService(ChatRoomDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<List<IdentityUser>> GetAllUsers()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}
