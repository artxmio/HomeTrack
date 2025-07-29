using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Interfaces;
using HomeTrack.Persistense;
using HomeTrack.UnitTests.Common;

namespace HomeTrack.IntegrationTests.Common;

public abstract class TestBase : IDisposable
{
    protected readonly HomeTrackDbContext Context;
    protected readonly IMapper Mapper;

    public TestBase()
    {
        Context = HomeTrackContextFactory.Create();

        var configurationBuilder = new MapperConfiguration(config =>
            config.AddProfile(new AssemblyMappingProfile(
                typeof(IHomeTrackDbContext).Assembly)
            )
        );

        Mapper = configurationBuilder.CreateMapper();
    }

    public void Dispose()
    {
        HomeTrackContextFactory.Destroy(Context);
    }
}