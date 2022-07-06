﻿namespace ChatRoomApp.Dtos
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
