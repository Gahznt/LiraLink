﻿namespace LiraLink.Services.AuthenticateService;

public interface IAuthenticateService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> UserExists(string email);
    public string GenerateToken(int id, string email);
}
