# How-to-get-rid-of-default-padding-around-the-numeric-entry-SfNumericTextBox-in-Xamarin.Forms

This article explains how to remove or adjust the default padding around the Xamarin.Forms Syncfusion SfNumericTextBox and its background with the following steps

 	 
![](default_appearance.png)

*Fig1: Default appearance of SfNumericTextBox*


![](removing_padding.png)

*Fig2: After removing its background and its default padding*

 
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

 <local:CustomNumericTextBox Value="123" VerticalOptions="Center"      BackgroundColor="LightGray"/>

 …
```

**Step 3:** Create a custom renderer to remove the default padding of the SfNumericTextBox using the platform specific code.
 
**Android: CustomNumericTextBoxRenderer.cs**

By setting the null to Background and setting the 0 to the padding of native control. 
  ```
[C#]
protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

            if (Control != null)
            {
               Control.Background = null;
               Control.SetPadding(0, 0,0,0);
            
            }
        }

```
**iOS: CustomNumericTextBoxRenderer.cs**

Default padding has been overridden through the EditTextLeftPadding. By using the reflection, it has been modified in iOS platform as shown in below
```
[C#]
 		protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
                              …

                var leftPadding = typeof(Syncfusion.SfNumericTextBox.iOS.SfNumericTextBox).GetProperty("EditTextLeftPadding", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                leftPadding.SetValue(Control, 0);
            }
        }
```
**WP: CustomNumericTextBoxRenderer.cs**

By setting the desired value to the Padding of native control, it will be achieved as shown in below
 ```
[C#]
        protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
              …

Control.Padding = new Windows.UI.Xaml.Thickness(0);
            }
        }

```

## See also

[How to assign nullable values in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/assign-nullable-value)

[How to customize the colors in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/colors)

[How to format the numeric value in Xamarin.Forms SfNumericTextBox](https://help.syncfusion.com/xamarin/numeric-entry/number-formatting)

[Available interaction in numeric control](https://help.syncfusion.com/xamarin/numeric-entry/events-and-interactivity)




