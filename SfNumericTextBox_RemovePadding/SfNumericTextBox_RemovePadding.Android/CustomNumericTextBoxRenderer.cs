using Android.Graphics.Drawables;
using SfNumericTextBox_RemovePadding;
using SfNumericTextBox_RemovePadding.Droid;
using Syncfusion.SfNumericTextBox.XForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomNumericTextBox), typeof(CustomNumericTextBoxRenderer))]
namespace SfNumericTextBox_RemovePadding.Droid
{
	public class CustomNumericTextBoxRenderer : SfNumericTextBoxRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox> e)
		{
			base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetPadding(0, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }
        }
    }
}