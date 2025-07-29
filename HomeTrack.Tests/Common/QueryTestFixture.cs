using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Interfaces;
using HomeTrack.Persistense;
using HomeTrack.UnitTests.Common;

namespace HomeTrack.IntegrationTests.Common;

public class QueryTestFixture: IDisposable
{
    public HomeTrackDbContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = HomeTrackContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                typeof(IHomeTrackDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        HomeTrackContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture> { }