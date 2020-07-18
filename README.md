# gestures
Cross-platform, multi-touch gesture recognition for Android, iOS, macOS, UWP and WPF.

[![Build Status](https://dev.azure.com/velocitysystems/gestures/_apis/build/status/velocitysystems.gestures?branchName=master)](https://dev.azure.com/velocitysystems/gestures/_build/latest?definitionId=1&branchName=master)

**Xamarin (.NET Standard)**
|Type|Android|iOS|macOS|
|---|---|---|---|
|`TapRecognizer`|✅|✅|✅|
|`LongPressRecognizer`|✅|✅|✅|
|`SwipeRecognizer`|❌|✅|✅|
|`PanRecognizer`|❌|✅|✅|
|`PinchRecognizer`|❌|✅|✅|
|`HoverRecognizer`|❌|❌|❌|

**Windows (.NET Standard)**
|Type|UWP|WPF|
|---|---|---|
|`TapRecognizer`|✅|✅|
|`LongPressRecognizer`|✅|✅|
|`SwipeRecognizer`|❌|❌|
|`PanRecognizer`|❌|❌|
|`PinchRecognizer`|❌|❌|
|`HoverRecognizer`|✅|✅|

**Xamarin.Forms**
|Type|Android|iOS|macOS|UWP|WPF|
|---|---|---|---|---|---|
|`TapGestureRecognizer`|✅|✅|✅|✅|✅|
|`LongPressGestureRecognizer`|✅|✅|✅|✅|✅|
|`SwipeGestureRecognizer`|❌|✅|✅|❌|❌|
|`PanGestureRecognizer`|❌|✅|✅|❌|❌|
|`PinchGestureRecognizer`|❌|✅|✅|❌|❌|
|`HoverGestureRecognizer`|❌|❌|❌|✅|✅|

**iOS**
1. Hover gesture recognizer requires iOS 13 and above.

**UWP**
1. Long-press gesture recognizer is triggered by a right-click.

**WPF**
1. For gestures to fire correctly in Xamarin.Forms, they must be attached to a View where the BackgroundColor is opaque (not transparent).
2. Long-press gesture recognizer is triggered by a right-click.