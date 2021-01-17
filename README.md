# gestures
[![Build Status](https://dev.azure.com/velocitysystems/gestures/_apis/build/status/velocitysystems.gestures?branchName=master)](https://dev.azure.com/velocitysystems/gestures/_build/latest?definitionId=1&branchName=master)

Cross-platform, multi-touch gesture and input recognition for Android, iOS, macOS, UWP and WPF.
- Supports tap, long-press, swipe, pan, pinch and hover gestures on all platforms
- Supports key listeners on desktop platforms (macOS, UWP, WPF)
- Xamarin support for Android, iOS and macOS.
- Xamarin.Forms support for all platforms.

## Recognizers

### Overview
All recognizers fire `TouchesBegan` and `TouchesEnded`. They may fire additional events dependent on their designated behavior. 

### Tap
Multi-touch, multi-tap gesture recognizer.
- **NumberOfTouchesRequired**: The number of touches required.
- **NumberOfTapsRequired**: The number of taps required.
- `Tapped`: The tapped event.

### Long-press
Multi-touch, long-press gesture recognizer.
- **NumberOfTouchesRequired**: The number of touches required.
- `LongPressed`: The long-pressed event.

### Swipe
Multi-touch, swipe gesture recognizer.
- **NumberOfTouchesRequired**: The number of touches required.
- **SwipeDirectionMask**: The swipe direction mask. Sets the allowable directions.
- `Swiped`: The swiped event with the direction.

### Pan
Pan gesture recognizer.
- **NumberOfTouchesRequired**: The number of touches required.
- `Panning`: The panning event with the current state and delta position.

### Pinch
Pinch gesture recognizer.
- **NumberOfTouchesRequired**: The number of touches required.
- `Pinching`: The pinching event with the current state and scale.

### Hover
Hover gesture recognizer. For desktop platforms, this is triggered by mouseover.
- `LongPressed`: The hovering event.

## Listeners

### Key
Key event listener (desktop platforms only). Supports multiple concurrent keys and key combinations.

- `Pressed`: The key(s) pressed event.
- `KeyDown`: The key down event.
- `KeyUp`: The key up event.

## Platforms

### Xamarin
|Type|Android|iOS|macOS|
|---|---|---|---|
|`TapRecognizer`|✅|✅|✅|
|`LongPressRecognizer`|✅|✅|✅|
|`SwipeRecognizer`|✅|✅|✅|
|`PanRecognizer`|✅|✅|✅|
|`PinchRecognizer`|✅|✅|✅|
|`HoverRecognizer`|✅|✅|✅|
|`KeyListener`|-|-|✅|

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

### Windows
|Type|UWP|WPF|
|---|---|---|
|`TapRecognizer`|✅|✅|
|`LongPressRecognizer`|✅|✅|
|`SwipeRecognizer`|✅|✅|
|`PanRecognizer`|✅|✅|
|`PinchRecognizer`|✅|✅|
|`HoverRecognizer`|✅|✅|
|`KeyListener`|✅|✅|

## Xamarin

### Usage
Recognizers can be attached to a native view by passing in a reference during construction.
They may be subsequently detached by calling the `Dispose` method. For example:

*Android*
```
var view = FindViewById<View>(Resource.Id.SomeView);
var recognizer = new TapGestureRecognizer(Context, view);
recognizer.Tapped.Subscribe(e => {
    ...
});
```

*iOS*
```
var view = new UIView();
var recognizer = new TapGestureRecognizer(view);
recognizer.Tapped.Subscribe(e => {
    ...
});
```

*macOS*
```
var view = new NSView();
var recognizer = new TapGestureRecognizer(view);
recognizer.Tapped.Subscribe(e => {
    ...
});
```

## Xamarin.Forms

### Usage
Recognizers or listeners can be attached to a `View` by adding them to the `GestureRecognizers` [collection](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.view.gesturerecognizers?view=xamarin-forms). For example:
```
var recognizer = new TapGestureRecognizer();
recognizer.Tapped += (sender, e) => {
    ...
};

View.GestureRecognizers.Add(recognizer);
```

Platform support is enabled by adding a `RecognizerEffect` or `ListenerEffect` to the `Effects` [collection](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.element.effects?view=xamarin-forms). For example:
```
View.Effects.Add(Effect.Resolve($"Velocity.{nameof(RecognizerEffect)}"));

View.Effects.Add(Effect.Resolve($"Velocity.{nameof(ListenerEffect)}"));
```

Note: If the effect is not added, the gesture or listener will not be handled by Xamarin.Forms.

### Supported Elements
|Element|Android|iOS|macOS|UWP|WPF|
|---|---|---|---|---|---|
|`AbsoluteLayout`|-|-|-|-|-|
|`ActivityIndicator`|-|-|-|-|-|
|`BoxView`|-|-|-|-|-|
|`Button`|-|-|-|-|-|
|`ContentPage`|-|-|-|-|-|
|`ContentView`|-|-|-|-|-|
|`DatePicker`|-|-|-|-|-|
|`Editor`|-|-|-|-|-|
|`Entry`|-|-|-|-|-|
|`Frame`|-|-|-|-|-|
|`Grid`|-|-|-|-|-|
|`Image`|-|-|-|-|-|
|`ImageButton`|-|-|-|-|-|
|`Label`|-|-|-|-|-|
|`ListView`|-|-|-|-|-|
|`Picker`|-|-|-|-|-|
|`ProgressBar`|-|-|-|-|-|
|`RelativeLayout`|-|-|-|-|-|
|`ScrollView`|-|-|-|-|-|
|`SearchBar`|-|-|-|-|-|
|`Slider`|-|-|-|-|-|
|`StackLayout`|-|-|-|-|-|
|`Stepper`|-|-|-|-|-|
|`Switch`|-|-|-|-|-|
|`TabbedPage`|-|-|-|-|-|
|`TableView`|-|-|-|-|-|
|`TimePicker`|-|-|-|-|-|
|`WebView`|-|-|-|-|-|

## Windows

Recognizers can be attached to a native view by passing in a reference during construction.
They may be subsequently detached by calling the `Dispose` method. For example:

*UWP/WPF*
```
var view = new Canvas();
var recognizer = new TapGestureRecognizer(view);
recognizer.Tapped.Subscribe(e => {
    ...
});
```

## Lifecycle Events
Recognizers and listeners may be attached and detached 'on-the-fly'. It is recommended that for managing the lifecycle of multiple recognizers, a `CompositeDisposable` is used. For example:

```
var view = FindViewById<View>(Resource.Id.SomeView);
var disposable = new CompositeDisposable();

disposable.Add(new TapGestureRecognizer(Context, view));
disposable.Add(new LongPressRecognizer(Context, view));
disposable.Add(new SwipeGestureRecognizer(Context, view));
```

When required to detach the recognizers, we can call:
```
disposable.Clear();
```

Or, if the `CompositeDisposable`  is no longer required:
```
disposable.Dispose();
```

## Advanced Scenarios

### Multiple Recognizers
Not all recognizers may work together concurrently. For example, you cannot use a `SwipeRecognizer` and `PanRecognizer` simulataneously.

## Support Notes

### Android
1. Hover recognizer requires hardware support.

### iOS
1. Hover recognizer requires iOS 13 and above.

### UWP
1. Long-press recognizer is triggered by right-click.
2. Hover recognizer triggered by mouseover.

### WPF
1. For gestures to work in Xamarin.Forms, they must be attached to a view where the background color is opaque (not transparent).
2. Long-press recognizer is triggered by right-click.
3. Hover recognizer triggered by mouseover.

## Remaining Work
- [X] Migrate to AndroidX
- [X] Add detection algorithms for platforms which do not offer native recognition.
- [ ] Add delay-based long-press recognition on macOS, UWP and WPF.
- [ ] Add multi-touch support for platforms which do not offer native recognition.
- [ ] Add unit tests for shared classes
- [ ] Add platform sample pages (non-Xamarin.Forms)
- [ ] Unify values returned by PinchGestureRecognizer across all platforms.
- [ ] Implement YAML build script