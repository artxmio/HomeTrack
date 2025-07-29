using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Residents.Queries.GetResidentDetails;
using HomeTrack.IntegrationTests.Common;
using HomeTrack.Persistense;
using HomeTrack.UnitTests.Common;

namespace HomeTrack.IntegrationTests.Residents.Queries;

[Collection("QueryCollection")]
public class GetResidentDetailsQueryHandlerTests(QueryTestFixture fixture)
{
    public readonly HomeTrackDbContext Context = fixture.Context;
    public readonly IMapper Mapper = fixture.Mapper;

    [Fact]
    public async Task GetResidentDetailsQueryHandler_Success()
    {
        //Arrange
        var handler = new GetResidentDetailsQueryHandler(Context, Mapper);
        var query = new GetResidentDetailsQuery()
        {
            Id = HomeTrackContextFactory.ResidentIdForGetDetails
        };
        
        //Act
        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.IsType<ResidentDetailsVm>(result);
        Assert.Equal("Name4", result.Name);
        Assert.Equal("Surname4", result.Surname);
        Assert.Equal(new DateTime(2024, 02, 15, 18, 00, 00), result.CreateDate);
    }

    [Fact]
    public async Task GetResidentDetailsQueryHandler_FailOnWrongId()
    {
        //Arrange
        var handler = new GetResidentDetailsQueryHandler(Context, Mapper);
        var query = new GetResidentDetailsQuery()
        {
            Id = Guid.NewGuid()
        };

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(query, CancellationToken.None);
        });
    }
}