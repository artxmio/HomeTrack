namespace HomeTrack.Persistense;

public class DbInitializer
{
    public static void Initialize(HomeTrackDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
