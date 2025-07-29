using HomeTrack.Domain;
using HomeTrack.Persistense;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.UnitTests.Common;

public class HomeTrackContextFactory
{
    public static Guid ResidentIdForDelete = Guid.NewGuid();
    public static Guid ResidentIdForUpdate = Guid.NewGuid();
    public static Guid ResidentIdForGetDetails = Guid.NewGuid();

    public static HomeTrackDbContext Create()
    {
        var options = new DbContextOptionsBuilder<HomeTrackDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new HomeTrackDbContext(options);
        context.Database.EnsureCreated();

        var testResidents = new List<Resident>
            {
                new() 
                {
                    Id          = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name        = "Name1",
                    Surname     = "Surname1",
                    CreateDate  = new DateTime(2023, 01, 10, 14, 30, 00),
                    UpdateDate  = null,
                    ApartmentId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                },
                new()
                {
                    Id          = ResidentIdForUpdate,
                    Name        = "Name2",
                    Surname     = "Surname2",
                    CreateDate  = new DateTime(2023, 03, 05, 09, 15, 00),
                    UpdateDate  = new DateTime(2023, 06, 01, 11, 45, 00),
                    ApartmentId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                },
                new() 
                {
                    Id          = ResidentIdForDelete,
                    Name        = "Name3",
                    Surname     = "Surname3",
                    CreateDate  = new DateTime(2024, 02, 15, 18, 00, 00),
                    UpdateDate  = null,
                    ApartmentId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                },
                new()
                {
                    Id          = ResidentIdForGetDetails,
                    Name        = "Name4",
                    Surname     = "Surname4",
                    CreateDate  = new DateTime(2024, 02, 15, 18, 00, 00),
                    UpdateDate  = null,
                    ApartmentId = null,
                },
            };

        context.AddRange(testResidents);

        context.SaveChanges();

        return context;
    }

    public static void Destroy(HomeTrackDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
