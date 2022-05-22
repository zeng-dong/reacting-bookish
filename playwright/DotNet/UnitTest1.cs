using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DotNet;

public class BookishAppTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task It_goes_to_the_page()
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://localhost:3000/");
    }
}