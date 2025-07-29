using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Residents.Commands.UpdateResident;
using HomeTrack.IntegrationTests.Common;
using HomeTrack.UnitTests.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.IntegrationTests.Residents.Commands;

public class UpdateResidentCommandHandlerTests 
    : TestBase
{
    [Fact]
    public async Task UpdateResidentCommandHandler_Success()
    {
        //Arrange
        var handler = new UpdateResidentCommandHandler(Context);
        var command = new UpdateResidentCommand()
        {
            Id = HomeTrackContextFactory.ResidentIdForUpdate,
            Name = "Updated Name",
            Surname = "Updated Surname"
        };

        //Act
        await handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.NotNull(
            Context.Residents.SingleOrDefaultAsync(r =>
                r.Id == HomeTrackContextFactory.ResidentIdForUpdate &&
                r.Name == command.Name &&
                r.Surname == command.Surname
        ));
    }

    [Fact]
    public async Task UpdateResidentCommandHandler_FailOnWrongId()
    {
        //Arrange
        var handler = new UpdateResidentCommandHandler(Context);
        var command = new UpdateResidentCommand()
        {
            Id = Guid.NewGuid(),
            Name = "Updated Name",
            Surname = "Updated Surname"
        };

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => 
            await handler.Handle(command, 
                CancellationToken.None));
    }
}