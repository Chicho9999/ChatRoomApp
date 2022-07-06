namespace ChatRoomApp.Services.Interface
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();
    }
}
