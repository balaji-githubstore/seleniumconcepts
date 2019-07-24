using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;
using n = OpenQA.Selenium.Support.Extensions;
using System.Drawing;

namespace SeleniumProject
{
    class MyTest
    {
        static void Main(string[] args)
        {

            //HardCode Path
            IWebDriver driverh1 = new ChromeDriver(@"D:\Mine\Company\Maveric\Driver\");
            IWebDriver driverh2 = new FirefoxDriver(@"D:\Mine\Company\Maveric\Driver\");
            IWebDriver driverh3 = new InternetExplorerDriver(@"D:\Mine\Company\Maveric\Driver\");

            //Bin folder
            IWebDriver driver1 = new ChromeDriver();
            IWebDriver driver2 = new FirefoxDriver();
            IWebDriver driver3 = new InternetExplorerDriver();

            //Relative path
            string currentPath = Directory.GetCurrentDirectory();

            String path = Directory.GetParent(currentPath).Parent.FullName;

            //String[] path = Directory.GetDirectories(@"D:\Mine\Specflow\SeleniumProject\SeleniumProject\bin\Debug");

            IWebDriver driver = new ChromeDriver(path + "/Driver/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Console.WriteLine(driver.Manage().Timeouts().ImplicitWait);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Url = "https://magento.com/";
            //driver methods and properties
            Console.WriteLine(driver.Url);

            Console.WriteLine(driver.Title);

            Console.WriteLine(driver.PageSource);

            IWebElement myAccount = driver.FindElement(By.LinkText("MY ACCOUNT"));
            myAccount.Click();
            //Thread.Sleep(5000);

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("balajidinakaran1@gmail.com");

            IWebElement pass = driver.FindElement(By.Id("pass"));
            pass.SendKeys("Welcome123");

            IWebElement login = driver.FindElement(By.Name("send"));
            login.Click();

            ReadOnlyCollection<IWebElement> anchorTag = driver.FindElements(By.TagName("a"));

            foreach (IWebElement e in anchorTag)
            {
                Console.WriteLine(e.Text);
                //   e.GetCssValue()

            }

            for (int i = 0; i < anchorTag.Count; i++)
            {
                Console.WriteLine(anchorTag[i].Text);
            }
            anchorTag[5].Click();


            //Navigation
            //driver.Navigate().GoToUrl(new Uri(""));
            Thread.Sleep(5000);
            driver.Navigate().Back();
            Thread.Sleep(5000);
            driver.Navigate().Forward();
            Thread.Sleep(5000);
            driver.Navigate().Refresh();

            //Alerts
            driver.Navigate().GoToUrl("http://www.echoecho.com/javascript4.htm");
            driver.FindElement(By.Name("B1")).Click();
            driver.FindElement(By.Name("B3")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            Thread.Sleep(5000);
            alert.Accept();
            alert.SendKeys("Check");
            Thread.Sleep(5000);
            alert.Dismiss();

            //Frames
            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";
            driver.SwitchTo().Frame("login_page");
            driver.FindElement(By.Name("fldLoginUserId")).SendKeys("bala1245");
            driver.FindElement(By.XPath("//img[@alt='continue']")).Click();

            //Mutliple Windows
            driver.Url = "https://account.magento.com/customer/account/create/";

            driver.FindElement(By.PartialLinkText("Terms")).Click();
            Thread.Sleep(5000);
            String parent = driver.CurrentWindowHandle;
            Console.WriteLine("Current window id" + parent);
            ReadOnlyCollection<String> windows = driver.WindowHandles;
            foreach (String w in windows)
            {
                Console.WriteLine(w);
            }

            driver.SwitchTo().Window(windows[windows.Count - 1]);
            driver.FindElement(By.LinkText("Privacy Policy")).Click();
            driver.Close();
            Thread.Sleep(5000);
            driver.SwitchTo().Window(windows[0]);
            driver.FindElement(By.Id("firstname")).SendKeys("hello");

            //Dropdown
            driver.Url = "https://account.magento.com/customer/account/create/";
            IWebElement dropdown = driver.FindElement(By.Id("customer_company_type"));
            SelectElement oSelect = new SelectElement(dropdown);
            oSelect.SelectByIndex(2);
            oSelect.SelectByText("");
            oSelect.SelectByValue("");

            //Mouse hover actions

            driver.Url = "https://www.amazon.in/";

            Actions actions = new Actions(driver);
            IWebElement category = driver.FindElement(By.XPath("//*[text()='Category']"));
            IWebElement echo = driver.FindElement(By.XPath("//*[text()='Echo & Alexa']"));
            IWebElement echoDot = driver.FindElement(By.XPath("//*[text()='Echo Dot']"));
            actions.MoveToElement(category).Build().Perform();
            Thread.Sleep(2000);
            actions.MoveToElement(echo).Build().Perform();
            Thread.Sleep(2000);
            actions.MoveToElement(echoDot).Click().Build().Perform();
            Thread.Sleep(2000);

            //driver.Url = "https://www.amazon.in/";
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //Actions actions = new Actions(driver);
            //IWebElement category = driver.FindElement(By.XPath("//*[text()='Category']"));
            //IWebElement echo = driver.FindElement(By.XPath("//*[text()='Echo & Alexa']"));
            //IWebElement echoDot = driver.FindElement(By.XPath("//*[text()='Echo Dot']"));
            //actions.MoveToElement(category).Build().Perform();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Echo & Alexa']")));
            //actions.MoveToElement(echo).Build().Perform();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Echo Dot']")));
            //actions.MoveToElement(echoDot).Build().Perform();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Echo Dot']")));
            //actions.Click().Build().Perform();
            //Thread.Sleep(1000);

            //driver.Url = "https://www.flipkart.com/";
            //driver.FindElement(By.XPath("//*[text()='✕']")).Click();
            //Thread.Sleep(2000);
            //Actions actions = new Actions(driver);
            //IWebElement category = driver.FindElement(By.XPath("(//*[contains(text(),'Electronics')])[2]"));
            //IWebElement echoDot = driver.FindElement(By.XPath("//*[text()='Mi']"));
            //actions.MoveToElement(category).Build().Perform();
            //Thread.Sleep(2000);
            //actions.MoveToElement(echoDot).Click().Build().Perform();
            //Thread.Sleep(2000);


            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //driver.Url = "https://www.flipkart.com/";
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='✕']")));
            //driver.FindElement(By.XPath("//*[text()='✕']")).Click();

            //Actions actions = new Actions(driver);
            //wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("(//*[contains(text(),'Electronics')])[2]")));
            //IWebElement category = driver.FindElement(By.XPath("(//*[contains(text(),'Electronics')])[2]"));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Mi']")));
            //IWebElement echoDot = driver.FindElement(By.XPath("//*[text()='Mi']"));
            //actions.MoveToElement(category).Build().Perform();

            //actions.MoveToElement(echoDot).Click().Build().Perform();


            ////Google mousehover and keyboard actions
            driver.Url = "https://www.google.co.in/";
            Actions actions2 = new Actions(driver);
            IWebElement gmail = driver.FindElement(By.LinkText("Gmail"));
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Gmail")));
            Thread.Sleep(5000);
            actions2.MoveToElement(gmail).Build().Perform();
            actions2.Click().Build().Perform();
            Thread.Sleep(5000);
            actions2.MoveToElement(driver.FindElement(By.Id("identifierId"))).Click().SendKeys("balaji").SendKeys(Keys.Enter).Build().Perform();

            //driver.Url = "https://www.google.co.in/";
            //Actions actions3 = new Actions(driver);
            //IWebElement search = driver.FindElement(By.Id("lst-ib"));
            //actions3.MoveToElement(search).Click().Build().Perform();
            //actions3.KeyDown(Keys.Shift).SendKeys("UpperCase").Build().Perform();
            //Thread.Sleep(5000);
            //actions3.SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Build().Perform();

            ////Chromeoptions
            //ChromeOptions opt = new ChromeOptions();
            //opt.AddArgument("--disable-notifications");
            //driver = new ChromeDriver(@"D:\Mine\Company\Maveric\Driver\", opt);
            //driver.Url = "https://cleartrip.com";

            ////size of browser
            //Size size = driver.Manage().Window.Size;
            //Console.WriteLine(size.Height);
            //Console.WriteLine(size.Width);
            //driver.Manage().Window.Size = new Size() { Height = 10, Width = 20 };
            //Point point = driver.FindElement(By.LinkText("")).Location;
            //Console.WriteLine(point.X);
            //Console.WriteLine(point.Y);
        }
    }
}
