# How to get rid of default left padding for the numeric entry (SfNumericTextBox) in Xamarin.Forms

This article explains how to remove or adjust the default left padding of the Xamarin.Forms Syncfusion SfNumericTextBox with the following steps
 	 

![](default_appearance.png)

*Fig1: Default appearance of SfNumericTextBox*


![](removing_padding.png)

*Fig2: After removing its default left padding*

 
**Step 1:** Create a custom SfNumericTextBox control, since it has been achieved through the custom renderer with the platform specific.
 
 ```
[C#]
    public class CustomNumericTextBox : SfNumericTextBox
    {

    }
```
**Step 2:** Add the CustomNumericTextBox control into your UI as follows.
 ```
[XAML]
  …

 <local:CustomNumericTextBox Value="123" VerticalOptions="Center" BackgroundColor="LightGray"/>

 …
```

**Step 3:** Create a custom renderer to remove the default left padding of the SfNumericTextBox using the platform specific code.
 
**Android: CustomNumericTextBoxRenderer.cs**

By setting the value 0 to the parameter left of SetPadding method of native control.
 
  ```
[C#]

  protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetPadding(0, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }
        }


```
**iOS: CustomNumericTextBoxRenderer.cs**

Default left padding has been overridden through the EditTextLeftPadding. By using the reflection, it has been modified in iOS platform as shown in below

```
[C#]
		protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
                var leftPadding = typeof(Syncfusion.SfNumericTextBox.iOS.SfNumericTextBox).GetProperty("EditTextLeftPadding", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                leftPadding.SetValue(Control, 0);
            }
        }
```
**UWP: CustomNumericTextBoxRenderer.cs**

By setting the desired value to the Padding of native control, it will be achieved as shown in below
 
 ```
[C#]
       protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Padding = new Windows.UI.Xaml.Thickness(0, Control.Padding.Top, Control.Padding.Right, Control.Padding.Bottom);
            }
        }

```

## See also

[How to create a borderless Xamarin.Forms SfNumericTextBox](https://www.syncfusion.com/kb/11980/how-to-create-a-borderless-xamarin-forms-numeric-control-sfnumerictextbox)

[How to assign nullable values in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/assign-nullable-value)

[How to customize the colors in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/colors)

[How to format the numeric value in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/number-formatting)

[Available interaction in numeric control](https://help.syncfusion.com/xamarin/numeric-entry/events-and-interactivity)




