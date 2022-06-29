namespace ChatRoomApp.Services.Interface
{
    public interface IUserService
    {
        Task<List<IdentityUser>> GetAllUsers();
    }
}
