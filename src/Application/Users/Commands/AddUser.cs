namespace Llano.Application.Users.Commands;

public sealed record class AddUser
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
