using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SControlBase
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:SControlBase"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:SControlBase;assembly=SControlBase"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CustomThumb/>
    ///
    /// </summary>
    public class CustomThumb : Thumb
    {
        static CustomThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomThumb), new FrameworkPropertyMetadata(typeof(CustomThumb)));
        }
        /// <summary>
        /// 指示标识是否开始就显示
        /// </summary>
        public static readonly DependencyProperty IsBounceProperty = DependencyProperty.Register(nameof(IsBounce), typeof(bool),
           typeof(CustomThumb), new PropertyMetadata(default(bool)));
        public bool IsBounce
        {
            get
            {
                return (bool)this.GetValue(IsBounceProperty);
            }
            set
            {
                this.SetValue(IsBounceProperty, value);
            }
        }
        public static readonly DependencyProperty IsDefaultProperty = DependencyProperty.Register(nameof(IsDefault),typeof(bool),
            typeof(CustomThumb),new PropertyMetadata(default(bool)));
        public bool IsDefault
        {
            get
            {
                return (bool)this.GetValue(IsDefaultProperty);
            }
            set
            {
                this.SetValue(IsDefaultProperty, value);
            }
        }
        protected override void OnDraggingChanged(DependencyPropertyChangedEventArgs e)
        {
            
            if (IsDragging && !IsBounce)
            {
                IsDefault = true;
            }
            else if (!IsDragging && !IsBounce)
            {
                IsDefault = false;
            }
            base.OnDraggingChanged(e);
        }
    }
}
