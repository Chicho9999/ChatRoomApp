namespace ChatRoomApp.Services.Interface
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> Authenticate(string username, string password);

    }
}
