using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Residents.Commands.DeleteResident;
using HomeTrack.IntegrationTests.Common;
using HomeTrack.UnitTests.Common;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.IntegrationTests.Residents.Commands;

public class DeleteResidentCommandHandlerTests
    : TestBase
{
    [Fact]
    public async Task DeleteResidentCommandHandler_Success()
    {
        //Arrange
        var handler = new DeleteResidentCommandHandler(Context);
        var residentId = HomeTrackContextFactory.ResidentIdForDelete;
        var command = new DeleteResidentCommand()
        {
            Id = residentId,
        };

        //Act
        await handler.Handle(command, CancellationToken.None);

        //Assert
        Assert.Null(await Context
            .Residents.SingleOrDefaultAsync(r => r.Id == residentId));
    }

    [Fact]
    public async Task DeleteResidentCommandHandler_FailOnWrongId()
    {
        //Arrange
        var handler = new DeleteResidentCommandHandler(Context);
        var command = new DeleteResidentCommand()
        {
            Id = Guid.NewGuid(),
        };

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(command, CancellationToken.None);
        });
    }
}
