using CupKeeper.Domains.Championships.ServiceModel;
using Microsoft.Extensions.DependencyInjection;

namespace CupKeeper.Tests;

[TestFixture]
public class UsaCyclingResultsTest
{
    [Test]
    public async Task CanLoadUsacResults()
    {
        var provider = TestInitializer.BuildServiceProvider();

        var loader = provider.GetRequiredService<IResultsLoader>();

        var results = await loader.GetResults("2024-12481"); // 2024 watts up time trial
        
        Assert.That(results, Is.Not.Null);
        Assert.That(results.Categories, Is.Not.Null);
        Assert.That(results.Categories, Is.Not.Empty);
        Assert.That(results.Categories, Has.Length.EqualTo(19));
        
        Assert.Pass();
    }
}