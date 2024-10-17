namespace gademo.Tests;

using NUnit.Framework;

[TestFixture]
public class MyEmptyTest
{
    [SetUp]
    public void Setup()
    {
        // This method runs before each test, but it's currently empty.
    }

    [Test]
    public void EmptyTest()
    {
        // This test does nothing, but is valid and will pass.
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        // This method runs after each test, but it's currently empty.
    }
}