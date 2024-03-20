using MallorcaTeslas.Application.Dtos.Customers;

namespace MallorcaTeslas.Application.Dtos.Users;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public CustomerDto Customer { get; set; } = null!;
}