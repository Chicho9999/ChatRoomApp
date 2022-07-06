using ChatRoom.Data.Models;
using ChatRoomApp.Services.Interface;

namespace ChatRoomApp.Services
{
    public class RoomService : IRoomService
    {
        public ChatRoomDbContext _dbContext;

        public RoomService(ChatRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _dbContext.Rooms.ToListAsync();
        }
    }
}
