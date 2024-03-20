namespace MallorcaTeslas.Application.Dtos.Users;

public class RegisterUserRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}