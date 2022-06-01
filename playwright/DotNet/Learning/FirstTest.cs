using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DotNet.Learning;

[Category("learning")]
public class FirstTest
{
    [Test]
    public async Task It_goes_to_app()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium
            .LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");

        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");
        var exists = await page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(exists);
    }
}