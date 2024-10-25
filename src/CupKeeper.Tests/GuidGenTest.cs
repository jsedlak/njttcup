using System.Diagnostics;

namespace CupKeeper.Tests;

[TestFixture]
public class GuidGenTest
{
    [Test]
    public void CanConvertYearToGuid()
    {
        int year = 2024;
        var id = year.ToString().ToGuid();
        
        Assert.That(id, Is.Not.EqualTo(Guid.Empty));

        Console.WriteLine(id);
    }
}