using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SocailMediaApp;
using SocailMediaApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(RoundedEntry),typeof(RoundedEntryRendererAndroid))]
namespace SocailMediaApp.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class RoundedEntryRendererAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(20f);
                gradientDrawable.SetStroke(2, Android.Graphics.Color.LightGray);
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete

}