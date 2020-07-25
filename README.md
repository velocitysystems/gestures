# gestures
Cross-platform, multi-touch gesture and user input recognition for Android, iOS, macOS, UWP and WPF.

[![Build Status](https://dev.azure.com/velocitysystems/gestures/_apis/build/status/velocitysystems.gestures?branchName=master)](https://dev.azure.com/velocitysystems/gestures/_build/latest?definitionId=1&branchName=master)

## Platforms

### Xamarin (.NET Standard)
|Type|Android|iOS|macOS|
|---|---|---|---|
|`TapRecognizer`|✅|✅|✅|
|`LongPressRecognizer`|✅|✅|✅|
|`SwipeRecognizer`|❌|✅|✅|
|`PanRecognizer`|❌|✅|✅|
|`PinchRecognizer`|❌|✅|✅|
|`HoverRecognizer`|✅|✅|✅|
|`KeyListener`|-|-|❌|

### Windows (.NET Standard)
|Type|UWP|WPF|
|---|---|---|
|`TapRecognizer`|✅|✅|
|`LongPressRecognizer`|✅|✅|
|`SwipeRecognizer`|❌|❌|
|`PanRecognizer`|❌|❌|
|`PinchRecognizer`|❌|❌|
|`HoverRecognizer`|✅|✅|
|`KeyListener`|✅|❌|

### Xamarin.Forms
|Type|Android|iOS|macOS|UWP|WPF|
|---|---|---|---|---|---|
|`TapGestureRecognizer`|✅|✅|✅|✅|✅|
|`LongPressGestureRecognizer`|✅|✅|✅|✅|✅|
|`SwipeGestureRecognizer`|❌|✅|✅|❌|❌|
|`PanGestureRecognizer`|❌|✅|✅|❌|❌|
|`PinchGestureRecognizer`|❌|✅|✅|❌|❌|
|`HoverGestureRecognizer`|✅|✅|✅|✅|✅|
|`KeyGestureListener`|-|-|❌|✅|❌|

## Support Notes

### Android
1. Hover recognizer requires hardware support.

### iOS
1. Hover recognizer requires iOS 13 and above.

### UWP
1. Long-press recognizer is triggered by a right-click.

### WPF
1. For gestures to work in Xamarin.Forms, they must be attached to a view where the background color is opaque (not transparent).
2. Long-press recognizer is triggered by a right-click.

## Remaining Work
- [ ] Add gesture detection algorithm for platforms which do not offer inbuilt recognition.
- [ ] Add platform support for swipe, pan and pinch gestures on Android, UWP and WPF.
- [ ] Add platform support for delay-based long-press recognition on macOS, UWP and WPF.
- [ ] Add unit tests for shared classes
- [ ] Add license validator implementation
- [ ] Add platform sample pags (non-Xamarin.Forms)
- [ ] Use multi-targeting for Android support libary and AndroidX support.
- [ ] Implement YAML build script
