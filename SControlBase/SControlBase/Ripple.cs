using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
    ///     <MyNamespace:Ripple/>
    ///
    /// </summary>
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateNormal)]
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateMousePressed)]
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateMouseOut)]
    public class Ripple : ContentControl
    {
        public const string TemplateStateNormal = "Normal";
        public const string TemplateStateMousePressed = "MousePressed";
        public const string TemplateStateMouseOut = "MouseOut";
        private static HashSet<Ripple> PressedInstances = new HashSet<Ripple>();
        static Ripple()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Ripple), new FrameworkPropertyMetadata(typeof(Ripple)));

            EventManager.RegisterClassHandler(typeof(ContentControl), Mouse.PreviewMouseUpEvent,
                new MouseButtonEventHandler(MouseButtonEventHandler), true);

            EventManager.RegisterClassHandler(typeof(ContentControl), Mouse.MouseMoveEvent,
                new MouseEventHandler(MouseMoveEventHandler), true);

            EventManager.RegisterClassHandler(typeof(Popup), Mouse.PreviewMouseUpEvent,
                new MouseButtonEventHandler(MouseButtonEventHandler), true);

            EventManager.RegisterClassHandler(typeof(Popup), Mouse.MouseMoveEvent,
                new MouseEventHandler(MouseMoveEventHandler), true);
        }
        public Ripple()
        {
            SizeChanged += OnSizeChanged;
        }

        private static void MouseButtonEventHandler(object sender, MouseButtonEventArgs args)
        {
            foreach (var ripple in PressedInstances)
            {
                var scaleTrans = ripple.Template.FindName("ScaleTransform", ripple) as ScaleTransform;
                if (scaleTrans != null)
                {
                    double currentScale = scaleTrans.ScaleX;
                    var newTime = TimeSpan.FromMilliseconds(300 * (1.0 - currentScale));

                    var scaleXKeyFrame = ripple.Template.FindName("MousePressedToNormalScaleXKeyFrame", ripple) as EasingDoubleKeyFrame;
                    if (scaleXKeyFrame != null)
                    {
                        scaleXKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
                    }
                    var scaleYKeyFrame = ripple.Template.FindName("MousePressedToNormalScaleYKeyFrame", ripple) as EasingDoubleKeyFrame;
                    if (scaleYKeyFrame != null)
                    {
                        scaleYKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
                    }
                }
                VisualStateManager.GoToState(ripple, TemplateStateNormal, true);
               
            }
            PressedInstances.Clear();
        }
        private static void MouseMoveEventHandler(object sender, MouseEventArgs args)
        {
            foreach (var ripple in PressedInstances.ToList())
            {
                var relativePosition = Mouse.GetPosition(ripple);
                if (relativePosition.X < 0 ||
                    relativePosition.Y < 0 ||
                    relativePosition.X > ripple.ActualWidth ||
                    relativePosition.Y > ripple.ActualHeight)
                {
                    VisualStateManager.GoToState(ripple, TemplateStateMouseOut, true);
                    PressedInstances.Remove(ripple);
                }
            }
        }
        public static readonly DependencyProperty FeedbackProperty = DependencyProperty.Register(nameof(Feedback), typeof(Brush), typeof(Ripple)
            , new PropertyMetadata(default(Brush)));
        public Brush Feedback
        {
            get { return (Brush)GetValue(FeedbackProperty); }
            set
            {
                SetValue(FeedbackProperty, value);
            }
        }
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            var point = e.GetPosition(this);

            if (RippleAssist.GetIsCentered(this))
            {
                var innerContent = (Content as FrameworkElement);

                if (innerContent != null)
                {
                    var position = innerContent.TransformToAncestor(this)
                        .Transform(new Point(0, 0));

                    RippleX = position.X + innerContent.ActualWidth / 2 - RippleSize / 2;
                    RippleY = position.Y + innerContent.ActualHeight / 2 - RippleSize / 2;
                }
                else
                {
                    RippleX = ActualWidth / 2 - RippleSize / 2;
                    RippleY = ActualHeight / 2 - RippleSize / 2;
                }
            }
            else
            {
                RippleX = point.X - RippleSize / 2;
                RippleY = point.Y - RippleSize / 2;
            }

            if (!RippleAssist.GetIsDisabled(this))
            {
                VisualStateManager.GoToState(this, TemplateStateNormal, false);
                VisualStateManager.GoToState(this, TemplateStateMousePressed, true);
                PressedInstances.Add(this);
            }

            base.OnPreviewMouseLeftButtonDown(e);
        }
        private static readonly DependencyPropertyKey RippleSizePropertyKey = DependencyProperty.RegisterReadOnly("RippleSize", typeof(double),
            typeof(Ripple), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty RippleSizeProperty = RippleSizePropertyKey.DependencyProperty;
        public double RippleSize
        {
            get { return (double)GetValue(RippleSizeProperty); }
            private set
            {
                SetValue(RippleSizePropertyKey, value);
            }
        }
        private static readonly DependencyPropertyKey RippleXPropertyKey = DependencyProperty.RegisterReadOnly("RippleX", typeof(double),
            typeof(Ripple), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty RippleXProperty = RippleXPropertyKey.DependencyProperty;
        public double RippleX
        {
            get { return (double)GetValue(RippleXProperty); }
            private set
            {
                SetValue(RippleXPropertyKey, value);
            }
        }
        private static readonly DependencyPropertyKey RippleYPropertyKey = DependencyProperty.RegisterReadOnly("RippleY", typeof(double),
            typeof(Ripple), new PropertyMetadata(default(double)));
        public static readonly DependencyProperty RippleYProperty = RippleYPropertyKey.DependencyProperty;
        public double RippleY
        {
            get
            {
                return (double)GetValue(RippleYProperty);
            }
            private set
            {
                SetValue(RippleYPropertyKey, value);
            }
        }
        public static readonly DependencyProperty RecognizesAccessKeyProperty = DependencyProperty.Register(nameof(RecognizesAccessKey), typeof(bool),
            typeof(Ripple), new PropertyMetadata(default(bool)));
        public bool RecognizesAccessKey
        {
            get { return (bool)GetValue(RecognizesAccessKeyProperty); }
            set
            {
                SetValue(RecognizesAccessKeyProperty, value);
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            VisualStateManager.GoToState(this, TemplateStateNormal,false);
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            var innerContent = (Content as FrameworkElement);
            double width, height;
            if (RippleAssist.GetIsCentered(this) && innerContent != null)
            {
                width = innerContent.ActualWidth;
                height = innerContent.ActualHeight;
            }
            else
            {
                width = sizeChangedEventArgs.NewSize.Width;
                height = sizeChangedEventArgs.NewSize.Height;
            }
            var radius = Math.Sqrt(Math.Pow(width, 2)+Math.Pow(height, 2));
            RippleSize = 2 * radius * RippleAssist.GetRippleSizeMultiplier(this);
        }
    }
}
