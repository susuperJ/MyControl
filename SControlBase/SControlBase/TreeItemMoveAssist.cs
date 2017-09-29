using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  TreeItemMoveAssist
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/29 14:17:14
    *描述： 
/************************************************************************************/

namespace SControlBase
{
   public static class TreeItemMoveAssist
    {
        public static readonly DependencyProperty IsMouseLeftDownProperty = DependencyProperty.RegisterAttached("IsMouseLeftDown",
            typeof(bool), typeof(TreeItemMoveAssist), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));
        public static bool GetIsMouseLeftDown(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseLeftDownProperty);
        }
        public static void SetIsMouseLeftDown(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseLeftDownProperty, value);
        }
    }
}
