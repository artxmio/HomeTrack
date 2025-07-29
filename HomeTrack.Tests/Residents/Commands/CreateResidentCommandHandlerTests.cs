using HomeTrack.Application.Residents.Commands.CreateResident;
using HomeTrack.IntegrationTests.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.IntegrationTests.Residents.Commands;

public class CreateResidentCommandHandlerTests 
    : TestBase
{
    [Fact]
    public async Task CreateResidentCommandHandler_Success()
    {
        //Arrange
        var handler = new CreateResidentCommandHandler(Context);
        
        var command = new CreateResidentCommand()
        {
            Name = "TestName",
            Surname = "TestSurname"
        };

        //Act
        var residentId = await handler.Handle(command, 
            CancellationToken.None);

        //Assert
        Assert.NotNull
            (
                await Context.Residents.SingleOrDefaultAsync(r => 
                    r.Id == residentId &&
                    r.Name == command.Name &&
                    r.Surname == command.Surname
                    )
            );
    }
}
