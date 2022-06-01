using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Learning;

[Category("learning")]
public class DerivedPageTest : PageTest
{
    [Test]
    public async Task Derived_page_test_goes_to_app()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
        await Page.ClickAsync("text=Login");

        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");
        await Page.ClickAsync("text=Log in");
        var exists = await Page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(exists);
    }
}