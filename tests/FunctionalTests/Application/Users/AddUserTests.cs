namespace Llano.FunctionalTests.Application.Users;

using Llano.Application.Users.Commands;

internal sealed class AddUserTests : TestBase
{
    [Test]
    public async Task AddUser_ShouldSucceed()
    {
        var messageBus = this.ServiceProvider.GetRequiredService<IMessageBus>();

        var command = new AddUser
        {
            Username = "testuser",
            Password = "testpassword",
        };

        await messageBus.SendAsync(command);
    }
}
