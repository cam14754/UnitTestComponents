Sample app to show off BaseTest and BaseViewTest using telerik components. In the xunit project, see XUnitInfra directory which is the current implementation on how to instantiate most visual tests. See ViewModelTests.cs and LabelTests.cs to show off successful uses of the base test to test maui visual components. See TelerikComponentTests.cs to see the common use case test.

In the test explorer window, note that 33 telerik tests pass and 25 fail.
The goal is to get all of them to pass with your help. If they are able to be instantiated, we can work from there to unit test our own bussiness logic.

The 3 main problems:
```
Message: 
System.TypeInitializationException : The type initializer for 'Telerik.Maui.Controls.SkiaSharp.SkiaTextPainter' threw an exception.
---- System.TypeInitializationException : The type initializer for 'Telerik.Maui.Controls.TextPaintable' threw an exception.
-------- System.Exception : Exception of type 'System.Exception' was thrown.

  Stack Trace: 
SkiaTextPainter.ctor()
SkiaStrokedTextPainter.ctor()
SkiaPurePainter.ctor(SkiaPurePainterContext context, SkiaPainterCacheSettings cacheSettings)
SkiaPainter.CreatePurePainter(PainterCreationContext painterCreationContext)
Painter.ctor(PainterCreationContext painterCreationContext)
SkiaPainter.ctor(SkiaPainterCacheSettings cacheSettings)
RadGaugeBase.ctor()
RadRadialGauge.ctor()
CustomStaticGauge.ctor() line 14
TelerikComponentTests.InitiateComplexControls() line 27
MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
----- Inner Stack Trace -----
TextPaintable.Initialize()
SkiaTextPainter.cctor()
----- Inner Stack Trace -----
NativeResourceProvider.GetDefaultLabelFontFamilyName()
TextPaintable.cctor()

```

```
Message: 
System.NullReferenceException : Object reference not set to an instance of an object.

  Stack Trace: 
VisualStateGroupListExtensions.HasVisualState(VisualElement element, String name)
PointerGestureRecognizer.SetupForPointerOverVSM(VisualElement element, Action`1 updatePointerState, PointerGestureRecognizer& recognizer)
View.CheckPointerOver()
View.ChangeVisualState()
RadButtonBase.ChangeVisualState()
VisualStateManager.VisualStateGroupsPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
BindableObject.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean didChange, Boolean willFirePropertyChanged)
Element.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean changed, Boolean willFirePropertyChanged)
BindableObject.SetValueActual(BindableProperty property, BindablePropertyContext context, Object value, Boolean currentlyApplying, SetValueFlags attributes, SetterSpecificity specificity, Boolean silent)
BindableObject.SetValueCore(BindableProperty property, Object value, SetValueFlags attributes, SetValuePrivateFlags privateAttributes, SetterSpecificity specificity)
BindableObject.SetValue(BindableProperty property, Object value, SetterSpecificity specificity)
Setter.Apply(BindableObject target, SetterSpecificity specificity)
Style.ApplyCore(BindableObject bindable, Style basedOn, SetterSpecificity specificity)
IStyle.Apply(BindableObject bindable, SetterSpecificity specificity)
MergedStyle.SetStyle(IStyle implicitStyle, IList`1 classStyles, IStyle style)
MergedStyle.set_Style(IStyle value)
<.cctor>b__14_0(BindableObject bindable, Object oldvalue, Object newvalue)
BindableObject.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean didChange, Boolean willFirePropertyChanged)
Element.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean changed, Boolean willFirePropertyChanged)
BindableObject.SetValueActual(BindableProperty property, BindablePropertyContext context, Object value, Boolean currentlyApplying, SetValueFlags attributes, SetterSpecificity specificity, Boolean silent)
BindableObject.SetValueCore(BindableProperty property, Object value, SetValueFlags attributes, SetValuePrivateFlags privateAttributes, SetterSpecificity specificity)
BindableObject.SetValue(BindableProperty property, Object value)
RadButtonBase.set_ActualStyle(Style value)
RadButtonBase.UpdateActualStyle(Style customStyle, Style implicitStyle)
RadButtonBase.UpdateActualStyle()
RadButtonBase.ctor()
RadTemplatedButton.ctor()
<InitializeComponent>_anonXamlCDataTemplate_40.LoadDataTemplate()
ElementTemplate.CreateContent()
TemplateUtilities.OnControlTemplateChanged(BindableObject bindable, Object oldValue, Object newValue)
BindableObject.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean didChange, Boolean willFirePropertyChanged)
Element.OnBindablePropertySet(BindableProperty property, Object original, Object value, Boolean changed, Boolean willFirePropertyChanged)
BindableObject.SetValueActual(BindableProperty property, BindablePropertyContext context, Object value, Boolean currentlyApplying, SetValueFlags attributes, SetterSpecificity specificity, Boolean silent)
BindableObject.SetValueCore(BindableProperty property, Object value, SetValueFlags attributes, SetValuePrivateFlags privateAttributes, SetterSpecificity specificity)
BindableObject.SetValue(BindableProperty property, Object value)
TemplatedView.set_ControlTemplate(ControlTemplate value)
RadAutoComplete.<OnControlTemplateChanged>b__263_0()
ConstructHelper.OnConstructed()
RadAutoComplete.ctor()
TelerikComponentTests.InstantiateAutoComplete() line 136
MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
```

```
Message: 
System.TypeInitializationException : The type initializer for 'Telerik.Maui.Controls.RadDataGrid' threw an exception.
---- System.InvalidOperationException : Requires the Color property to be set.

  Stack Trace: 
RadDataGrid.ctor()
TelerikComponentTests.InstantiateDataGrid() line 56
MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
----- Inner Stack Trace -----
ColorFilterExtension.ProvideValue(IServiceProvider serviceProvider)
RadDataGridResources.InitializeComponent()
RadDataGridResources.ctor()
RadDataGridResources.get_Resources()
RadDataGridResources.GetResource(String resourceKey)
RadDataGridResources.get_DataGridRowDetailsTemplate()
RadDataGrid.cctor()
```
