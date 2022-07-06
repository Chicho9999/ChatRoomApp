using ChatRoomApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomApp.Controllers.Api
{
    [Authorize]
    [Route("api/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("GetAllRooms")]
        public async Task<IActionResult> GetAllRoom()
        {
            var rooms = await _roomService.GetAllRooms();

            return Ok(rooms);
        }
    }
}