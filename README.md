# gestures
Cross-platform, multi-touch gesture and user input recognition for Android, iOS, macOS, UWP and WPF.

[![Build Status](https://dev.azure.com/velocitysystems/gestures/_apis/build/status/velocitysystems.gestures?branchName=master)](https://dev.azure.com/velocitysystems/gestures/_build/latest?definitionId=1&branchName=master)

**Xamarin (.NET Standard)**
|Type|Android|iOS|macOS|
|---|---|---|---|
|`TapRecognizer`|✅|✅|✅|
|`LongPressRecognizer`|✅|✅|✅|
|`SwipeRecognizer`|❌|✅|✅|
|`PanRecognizer`|❌|✅|✅|
|`PinchRecognizer`|❌|✅|✅|
|`HoverRecognizer`|✅|✅|✅|
|`KeyRecognizer`|-|-|❌|

**Windows (.NET Standard)**
|Type|UWP|WPF|
|---|---|---|
|`TapRecognizer`|✅|✅|
|`LongPressRecognizer`|✅|✅|
|`SwipeRecognizer`|❌|❌|
|`PanRecognizer`|❌|❌|
|`PinchRecognizer`|❌|❌|
|`HoverRecognizer`|✅|✅|
|`KeyRecognizer`|❌|❌|

**Xamarin.Forms**
|Type|Android|iOS|macOS|UWP|WPF|
|---|---|---|---|---|---|
|`TapGestureRecognizer`|✅|✅|✅|✅|✅|
|`LongPressGestureRecognizer`|✅|✅|✅|✅|✅|
|`SwipeGestureRecognizer`|❌|✅|✅|❌|❌|
|`PanGestureRecognizer`|❌|✅|✅|❌|❌|
|`PinchGestureRecognizer`|❌|✅|✅|❌|❌|
|`HoverGestureRecognizer`|✅|✅|✅|✅|✅|
|`KeyGestureRecognizer`|-|-|❌|❌|❌|

**Android**
1. Hover recognizer requires hardware support.

**iOS**
1. Hover recognizer requires iOS 13 and above.

**UWP**
1. Long-press recognizer is triggered by a right-click.

**WPF**
1. For gestures to work in Xamarin.Forms, they must be attached to a view where the background color is opaque (not transparent).
2. Long-press recognizer is triggered by a right-click.