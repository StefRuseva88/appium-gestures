using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Interactions;

namespace DragAndDrop
{
    public class DragAndDropTests
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
        public void DragAndDropTest()
        {
            IWebElement viewsBtn = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            viewsBtn.Click();

            IWebElement dragDropBtn = _driver.FindElement(MobileBy.AccessibilityId("Drag and Drop"));
            dragDropBtn.Click();

            AppiumElement firstDot = _driver.FindElement(MobileBy.Id("drag_dot_1"));

            AppiumElement secondDot = _driver.FindElement(MobileBy.Id("drag_dot_2"));

            var scriptArgs = new Dictionary<string, object>
            {
                { "elementId", firstDot.Id},
                { "endX", secondDot.Location.X + (secondDot.Size.Width/2) },
                { "endY", secondDot.Location.Y + (secondDot.Size.Height/2) },
                { "speed", 3000 }
            };

            _driver.ExecuteScript("mobile: dragGesture", scriptArgs);

            var dopedSuccessMsg = _driver.FindElement(MobileBy.Id("drag_result_text"));
            Assert.That(dopedSuccessMsg.Text, Is.EqualTo("Dropped!"), "The drag and drop action was not completed!");
        }
    }
}