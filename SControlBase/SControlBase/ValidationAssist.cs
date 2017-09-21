using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

/************************************************************************************
    *命名空间：SControlBase.Propertys
    *文件名：  ValidationAssist
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 11:34:29
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public static class ValidationAssist
    {
        #region ShowOnFocusProperty

        /// <summary>
        /// The hint property
        /// </summary>
        public static readonly DependencyProperty OnlyShowOnFocusProperty = DependencyProperty.RegisterAttached(
            "OnlyShowOnFocus",
            typeof(bool),
            typeof(ValidationAssist),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        public static bool GetOnlyShowOnFocus(DependencyObject element)
        {
            return (bool)element.GetValue(OnlyShowOnFocusProperty);
        }

        public static void SetOnlyShowOnFocus(DependencyObject element, bool value)
        {
            element.SetValue(OnlyShowOnFocusProperty, value);
        }

        #endregion

        #region UsePopupProperty

        /// <summary>
        /// The hint property
        /// </summary>
        public static readonly DependencyProperty UsePopupProperty = DependencyProperty.RegisterAttached(
            "UsePopup",
            typeof(bool),
            typeof(ValidationAssist),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        public static bool GetUsePopup(DependencyObject element)
        {
            Console.WriteLine("1111111");
            return (bool)element.GetValue(OnlyShowOnFocusProperty);

        }

        public static void SetUsePopup(DependencyObject element, bool value)
        {
            Console.WriteLine("1111111");
            element.SetValue(OnlyShowOnFocusProperty, value);
        }

        #endregion

        /// <summary>
        /// Framework use only.
        /// </summary>
        public static readonly DependencyProperty SuppressProperty = DependencyProperty.RegisterAttached(
            "Suppress", typeof(bool), typeof(ValidationAssist), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Framework use only.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetSuppress(DependencyObject element, bool value)
        {
            element.SetValue(SuppressProperty, value);
            Console.WriteLine("1111111");
        }

        /// <summary>
        /// Framework use only.
        /// </summary>
        public static bool GetSuppress(DependencyObject element)
        {
            Console.WriteLine("1111111");
            return (bool)element.GetValue(SuppressProperty);
        }
            
            
    }
}
