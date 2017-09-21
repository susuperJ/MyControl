using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SControlBase
{
   public class SliderAssist
    {
        public static readonly DependencyProperty IsBounceProperty = DependencyProperty.RegisterAttached("IsBounce", typeof(bool),
            typeof(SliderAssist), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        public static bool GetIsBounce(DependencyObject element)
        {
            return (bool)element.GetValue(IsBounceProperty);
        }
        public static void SetIsBounce(DependencyObject element, bool value)
        {
            element.SetValue(IsBounceProperty, value);
        }
    }
}
