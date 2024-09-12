using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;

namespace Swipe
{
    public class SwipeTests
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService;

        [OneTimeSetUp]
        public void Setup()
        {
            _appiumLocalService = new AppiumServiceBuilder().WithIPAddress("127.0.0.1").UsingPort(4723).Build();
            _appiumLocalService.Start();

            var androidOptions = new AppiumOptions();
            androidOptions.PlatformName = "Android";
            androidOptions.AutomationName = "UiAutomator2";
            androidOptions.PlatformVersion = "14.0";
            androidOptions.DeviceName = "Pixel_7_API_34";
            androidOptions.App = @"C:\Users\Stef\Desktop\ApiDemos-debug.apk";

            _driver = new AndroidDriver(_appiumLocalService, androidOptions);

            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(20);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService?.Dispose();
        }

        [Test]
        public void SwipeTest()
        {
            IWebElement viewsBtn = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            viewsBtn.Click();

            IWebElement GalleryBtn = _driver.FindElement(MobileBy.AccessibilityId("Gallery"));
            GalleryBtn.Click();

            IWebElement photoBtn = _driver.FindElement(MobileBy.AccessibilityId("1. Photos"));
            photoBtn.Click();

            var firstImage = _driver.FindElements(By.ClassName("android.widget.ImageView"))[0];

            var actions = new Actions(_driver);

            var swipe = actions.ClickAndHold(firstImage)
                .MoveByOffset(-200, 0)
                .Release()
                .Build();
            swipe.Perform();

            var thirdImage = _driver.FindElements(By.ClassName("android.widget.ImageView"))[2];

            Assert.That(thirdImage, Is.Not.Null, "The third image is not visible.");
        }
    }
}