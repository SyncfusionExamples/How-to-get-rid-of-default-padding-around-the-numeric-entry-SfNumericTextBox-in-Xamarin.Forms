using SfNumericTextBox_RemovePadding;
using SfNumericTextBox_RemovePadding.UWP;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.SfNumericTextBox.XForms.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomNumericTextBox), typeof(CustomNumericTextBoxRenderer))]
namespace SfNumericTextBox_RemovePadding.UWP
{
    class CustomNumericTextBoxRenderer : SfNumericTextBoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                Control.Padding = new Windows.UI.Xaml.Thickness(0);
            }
        }
    }
}