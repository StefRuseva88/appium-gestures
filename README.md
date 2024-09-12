# Mobile Gestures Automation with Appium
[![C#](https://img.shields.io/badge/Made%20with-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-5C2D91.svg)](https://dotnet.microsoft.com/)
[![Android Studio](https://img.shields.io/badge/Built%20with-Android%20Studio-3DDC84.svg)](https://developer.android.com/studio)
[![Appium](https://img.shields.io/badge/tested%20with-Appium-41BDF5.svg)](https://appium.io/)

### This is a test project for Front-End Test Automation July 2024 Course @ SoftUni
---
## Overview
This repository provides a set of tests focused on automating common mobile gestures using **Appium** for mobile app testing, that includes gestures like taps, swipes, scrolls, drag-and-drop, and zoom using the **ApiDemos** app.

### Table of Contents:
- [Mobile Gestures Overview](#mobile-gestures-overview)
- [Scrolling](#scrolling)
- [Swiping](#swiping)
- [Drag and Drop](#drag-and-drop)
- [Sliding Seek Bar](#sliding-seek-bar)
- [Zoom In/Out](#zoom-in/out)
- [Running the Tests](#running-the-tests)

### Prerequisites:
- Install Appium Server.
- Install Appium Inspector.
- **ApiDemos-debug.apk** file.
- Set up a virtual or real Android device for testing.
  
## Mobile Gestures Overview

Mobile gestures simulate user interactions on touch devices like smartphones and tablets. These interactions include:
- **Tap**: Quick touch, similar to a mouse click.
- **Long Press**: Touch and hold an element.
- **Swipe**: Move your finger across the screen to scroll or switch views.
- **Scroll**: Navigate content that extends beyond the screen's view.
- **Drag and Drop**: Move an object by dragging and releasing it.
- **Zoom In/Out**: Use two fingers to change zoom levels.

## Scrolling

### Test Objective:
- Automate scrolling actions using **Appium Inspector**.
- Write the **ScrollToText** method to scroll until the text **"Lists"** is found.
- Click on **Lists** and verify that **" Single choice list"** is displayed.

## Swiping

### Test Objective:
- Automate swipe gestures using **Appium Inspector**.
- Use Selenium's Actions class to simulate swiping.
- Click and hold on the first image, move by an offset, and release.
- Verify that the third image is visible.

## Drag and Drop

### Test Objective:

- Automate drag and drop gestures.
- Use **By.Id** to find the draggable and drop target elements.
- Use JavaScript actions to drag and drop the first red dot over the second one.
- Verify that the **"Dropped!"** message is displayed.

## Sliding Seek Bar

### Test Objective:
- Automate sliding actions for a seek bar.
- Use Appium Inspector's **Coordinates Mode** to get the precise sliding coordinates.
- Slide the seek bar to a specific value and assert the value is displayed.
- Write **MoveSeekBarWithInspectorCoordinates** method to slide the bar from the start to the end coordinates.
- Verify the displayed value matches the expected result.

## Zoom In/Out

### Test Objective:
- Automate zoom gestures using Appium Inspector.
- Use Appium Inspector to create a zoom-in gesture and execute it.
- Zoom out using similar steps.
- Use the saved gesture to zoom in and out at specific coordinates on the **WebView**.

## Contributing
Contributions are welcome! If you have any improvements or bug fixes, feel free to open a pull request.

## License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or suggestions, please open an issue in the repository.

---
### Happy Testing! 🚀
