using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SControlBase
{
   public static class RippleAssist
    {
        public static readonly DependencyProperty ClipToBoundsProperty = DependencyProperty.RegisterAttached("ClipToBounds", typeof(bool),
            typeof(RippleAssist), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.Inherits));
        public static void SetClipToBounds(DependencyObject element,bool value)
        {
            element.SetValue(ClipToBoundsProperty, value);
        }
        public static bool GetClipToBounds(DependencyObject element)
        {
            return (bool)element.GetValue(ClipToBoundsProperty);
        }

        public static readonly DependencyProperty IsCenteredProperty = DependencyProperty.RegisterAttached("IsCentered",
            typeof(bool), typeof(RippleAssist), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        public static void SetIsCentered(DependencyObject element, bool value)
        {
            element.SetValue(IsCenteredProperty, value);
        }
        public static bool GetIsCentered(DependencyObject element)
        {
            return (bool)element.GetValue(IsCenteredProperty);
        }

        public static readonly DependencyProperty IsDisabledProperty = DependencyProperty.RegisterAttached("IsDisabled", typeof(bool),
            typeof(Ripple), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        public static void SetIsDisabled(DependencyObject element, bool value)
        {
            element.SetValue(IsDisabledProperty, value);
        }
        public static bool GetIsDisabled(DependencyObject element)
        {
            return (bool)element.GetValue(IsDisabledProperty);
        }
        public static readonly DependencyProperty RippleSizeMultiplierProperty = DependencyProperty.RegisterAttached("RippleSizeMultiplier",
            typeof(double), typeof(RippleAssist), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.Inherits));
        public static void SetRippleSizeMultiplier(DependencyObject element, double value)
        {
            element.SetValue(RippleSizeMultiplierProperty, value);
        }
        public static double GetRippleSizeMultiplier(DependencyObject element)
        {
            return (double)element.GetValue(RippleSizeMultiplierProperty);
        }
        public static readonly DependencyProperty FeedbackProperty = DependencyProperty.RegisterAttached("Feedback", typeof(Brush),
            typeof(RippleAssist), new FrameworkPropertyMetadata(default(Brush), FrameworkPropertyMetadataOptions.Inherits));
        public static void SetFeedback(DependencyObject element,Brush value)
        {
            element.SetValue(FeedbackProperty, value);
        }
        public static Brush GetFeedback(DependencyObject element)
        {
            return (Brush)element.GetValue(FeedbackProperty);
        }
}
    
}
