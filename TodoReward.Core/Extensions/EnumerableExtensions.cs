using TodoReward.Core.Models;

namespace TodoReward.Core.Extensions;

public static class EnumerableExtensions
{
    public static T GetRandom<T>(this IEnumerable<T> collection) 
        where T : BaseEntity
    {
        var pot = collection.Select(i => i.Id).ToList();
        return collection.GetRandomFromPot(pot);
    }

    public static T GetRandomFromPot<T>(this IEnumerable<T> collection, IList<string> pot) 
        where T : BaseEntity
    {
        var rnd = new Random();

        var i = rnd.Next(pot.Count - 1);

        var rndRewardId = pot[i];

        return collection.Single(r => r.Id == rndRewardId);
    }
}
