using SControlBase.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    ///     xmlns:MyNamespace="clr-namespace:SControlBase.Transitions"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:SControlBase.Transitions;assembly=SControlBase.Transitions"
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
    ///     <MyNamespace:TransitionerSlide/>
    ///
    /// </summary>
    public class TransitionerSlide : TransitioningContentBase
    {
        static TransitionerSlide()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TransitionerSlide), new FrameworkPropertyMetadata(typeof(TransitionerSlide)));
        }

        public static readonly DependencyProperty TransitionOriginProperty = DependencyProperty.Register(
            "TransitionOrigin", typeof(Point), typeof(Transitioner), new PropertyMetadata(new Point(0.5, 0.5)));

        public Point TransitionOrigin
        {
            get { return (Point)GetValue(TransitionOriginProperty); }
            set { SetValue(TransitionOriginProperty, value); }
        }

        public static RoutedEvent InTransitionFinished =
            EventManager.RegisterRoutedEvent("InTransitionFinished", RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                typeof(TransitionerSlide));

        protected void OnInTransitionFinished(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("State", typeof(TransitionerSlideState), typeof(TransitionerSlide), new PropertyMetadata(default(TransitionerSlideState), new PropertyChangedCallback(StatePropertyChangedCallback)));

        private static void StatePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TransitionerSlide)d).AnimateToState();
        }

        public TransitionerSlideState State
        {
            get { return (TransitionerSlideState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty ForwardWipeProperty = DependencyProperty.Register(
            "ForwardWipe", typeof(ITransitionWipe), typeof(TransitionerSlide), new PropertyMetadata(new CircleWipe()));

        public ITransitionWipe ForwardWipe
        {
            get { return (ITransitionWipe)GetValue(ForwardWipeProperty); }
            set { SetValue(ForwardWipeProperty, value); }
        }

        public static readonly DependencyProperty BackwardWipeProperty = DependencyProperty.Register(
            "BackwardWipe", typeof(ITransitionWipe), typeof(TransitionerSlide), new PropertyMetadata(new SlideOutWipe()));

        public ITransitionWipe BackwardWipe
        {
            get { return (ITransitionWipe)GetValue(BackwardWipeProperty); }
            set { SetValue(BackwardWipeProperty, value); }
        }

        private void AnimateToState()
        {
            if (State != TransitionerSlideState.Current) return;

            RunOpeningEffects();
        }
    }
}
