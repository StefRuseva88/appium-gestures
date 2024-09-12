using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;

namespace Zoom
{
    public class ZoomTests
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
        public void ZoomInTeast()
        {
            IWebElement viewsBtn = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            viewsBtn.Click();

            ScrollToText("WebView");

            IWebElement webViewBtn = _driver.FindElement(MobileBy.AccessibilityId("WebView"));
            webViewBtn.Click();

            PerformZoomIn(431, 727, 258, 446, 550, 988, 792, 1222);
        }

        [Test]
        public void ZoomOutTest()
        {
            IWebElement viewsBtn = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            viewsBtn.Click();

            ScrollToText("WebView");

            IWebElement webViewBtn = _driver.FindElement(MobileBy.AccessibilityId("WebView"));
            webViewBtn.Click();

            PerformZoomOut(258, 446, 431, 727, 792, 1222, 550, 988);
        }

        private void ScrollToText(string text)
        {
            _driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"" + text + "\"));"));
        }

        private void PerformZoomIn(int ffStartX, int ffStartY, int ffEndX, int ffEndY, int sfStartX, int sfStartY, int sfEndX, int sfEndY)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomIn1 = new ActionSequence(finger1);
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, ffStartX, ffStartY, TimeSpan.Zero));
            zoomIn1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, ffEndX, ffEndY, TimeSpan.FromSeconds(5)));
            zoomIn1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomIn2 = new ActionSequence(finger2);
            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, sfStartX, sfStartY, TimeSpan.Zero));
            zoomIn2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, sfEndX, sfEndY, TimeSpan.FromSeconds(5)));
            zoomIn2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            _driver.PerformActions(new List<ActionSequence> { zoomIn1, zoomIn2 });
        }

        private void PerformZoomOut(int ffStartX, int ffStartY, int ffEndX, int ffEndY, int sfStartX, int sfStartY, int sfEndX, int sfEndY)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomOut1 = new ActionSequence(finger1);
            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, ffStartX, ffStartY, TimeSpan.Zero));
            zoomOut1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, ffEndX, ffEndY, TimeSpan.FromSeconds(5)));
            zoomOut1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomOut2 = new ActionSequence(finger2);
            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, sfStartX, sfStartY, TimeSpan.Zero));
            zoomOut2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, sfEndX, sfEndY, TimeSpan.FromSeconds(5)));
            zoomOut2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            _driver.PerformActions(new List<ActionSequence> { zoomOut1, zoomOut2 });
        }
    }
}