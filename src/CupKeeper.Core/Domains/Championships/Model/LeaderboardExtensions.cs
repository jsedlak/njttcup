namespace CupKeeper.Domains.Championships.Model;

public static class LeaderboardExtensions
{
    public static CategoryLeaderboard GetOrSet(this IList<CategoryLeaderboard> leaderboards, string categoryName)
    {
        var leaderboard = leaderboards.FirstOrDefault(x => x.Name == categoryName);

        if (leaderboard == null)
        {
            leaderboard = new CategoryLeaderboard
            {
                Name = categoryName
            };
            
            leaderboards.Add(leaderboard);
        }
        
        return leaderboard;
    }

    public static RiderLeaderboardPlacing GetOrSet(this CategoryLeaderboard category, Guid riderId)
    {
        var rider = category.Riders.FirstOrDefault(x => x.Id == riderId);

        if (rider == null)
        {
            rider = new RiderLeaderboardPlacing
            {
                RiderId = riderId,
            };
            
            category.Riders = category.Riders.Append(rider).ToArray();
        }
        
        return rider;
    }
}