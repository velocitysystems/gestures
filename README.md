# gestures
Cross-platform, multi-touch gesture and input recognition using RX for Android, iOS, macOS, UWP and WPF.

[![Build Status](https://dev.azure.com/velocitysystems/gestures/_apis/build/status/velocitysystems.gestures?branchName=master)](https://dev.azure.com/velocitysystems/gestures/_build/latest?definitionId=1&branchName=master)

## Platforms

### Xamarin (.NET Standard)
|Type|Android|iOS|macOS|
|---|---|---|---|
|`TapRecognizer`|✅|✅|✅|
|`LongPressRecognizer`|✅|✅|✅|
|`SwipeRecognizer`|✅|✅|✅|
|`PanRecognizer`|✅|✅|✅|
|`PinchRecognizer`|✅|✅|✅|
|`HoverRecognizer`|✅|✅|✅|
|`KeyListener`|-|-|✅|

### Windows (.NET Standard)
|Type|UWP|WPF|
|---|---|---|
|`TapRecognizer`|✅|✅|
|`LongPressRecognizer`|✅|✅|
|`SwipeRecognizer`|✅|✅|
|`PanRecognizer`|✅|✅|
|`PinchRecognizer`|✅|✅|
|`HoverRecognizer`|✅|✅|
|`KeyListener`|✅|✅|

### Xamarin.Forms
|Type|Android|iOS|macOS|UWP|WPF|
|---|---|---|---|---|---|
|`TapGestureRecognizer`|✅|✅|✅|✅|✅|
|`LongPressGestureRecognizer`|✅|✅|✅|✅|✅|
|`SwipeGestureRecognizer`|✅|✅|✅|✅|✅|
|`PanGestureRecognizer`|✅|✅|✅|✅|✅|
|`PinchGestureRecognizer`|✅|✅|✅|✅|✅|
|`HoverGestureRecognizer`|✅|✅|✅|✅|✅|
|`KeyGestureListener`|-|-|✅|✅|✅|

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
- [X] Migrate to AndroidX
- [X] Add detection algorithms for platforms which do not offer native recognition.
- [ ] Add delay-based long-press recognition on macOS, UWP and WPF.
- [ ] Add multi-touch support for platforms which do not offer native recognition.
- [ ] Add unit tests for shared classes
- [ ] Add platform sample pages (non-Xamarin.Forms)
- [ ] Unify values returned by PinchGestureRecognizer across all platforms.
- [ ] Implement YAML build script