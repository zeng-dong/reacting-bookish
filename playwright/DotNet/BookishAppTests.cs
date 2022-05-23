using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DotNet;

public class BookishAppTests
{
    // need to run from the project folder:   pwsh bin\Debug\net6.0\playwright.ps1 install

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
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "BookishApp.jpg"               // under bin folder
        });
    }

    [Test]
    public async Task It_lists_books()
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://localhost:3000/");
        var exists = await page.Locator("div.book-item").IsVisibleAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "BookishBooks.jpg"               // under bin folder
        });
        Assert.True(exists);
    }
}