using AutoMapper;
using HomeTrack.Application.Residents.Queries.GetResidentList;
using HomeTrack.IntegrationTests.Common;
using HomeTrack.Persistense;

namespace HomeTrack.IntegrationTests.Residents.Queries;

[Collection("QueryCollection")]
public class GetResidentListQueryHandlerTests(QueryTestFixture fixture)
{
    public readonly HomeTrackDbContext Context = fixture.Context;
    public readonly IMapper Mapper = fixture.Mapper;

    [Fact]
    public async Task GetResidentListQueryHandler_Success()
    {
        //Arrange
        var handler = new GetResidentListQueryHandler(Context, Mapper);
        var query = new GetResidentListQuery();

        //Act
        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.IsType<ResidentListVm>(result);
        Assert.Equal(4, result.Residents.Count);
    }
}