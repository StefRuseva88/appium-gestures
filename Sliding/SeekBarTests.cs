using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace Sliding
{
    public class SeekBarTests
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
        public void SeekBarTest()
        {
            IWebElement viewsBtn = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            viewsBtn.Click();

            ScrollToText("Seek Bar");

            AppiumElement seekBarBtn = _driver.FindElement(MobileBy.AccessibilityId("Seek Bar"));
            seekBarBtn.Click();

            MoveSeekBarWithInspectorCoordinates(546, 300, 1052, 300);

            var resultElement = _driver.FindElement(MobileBy.Id("io.appium.android.apis:id/progress"));
            var resultText = resultElement.Text;

            Assert.That(resultText, Is.EqualTo("100 from touch=true"));
        }

        private void MoveSeekBarWithInspectorCoordinates(int startX, int startY, int endX, int endY)
        {
            var finger = new PointerInputDevice(PointerKind.Touch);
            var start = new Point(startX, startY);
            var end = new Point(endX, endY);
            var swipe = new ActionSequence(finger);

            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromSeconds(10)));
            swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));
            _driver.PerformActions(new List<ActionSequence> { swipe });
        }
        private void ScrollToText(string text)
        {
            _driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"" + text + "\"));"));
        }
    }
}