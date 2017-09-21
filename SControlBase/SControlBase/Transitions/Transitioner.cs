using SControlBase.Transitions;
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
    ///     <MyNamespace:Transitioner/>
    ///
    /// </summary>
    /// <summary>
    /// The transitioner provides an easy way to move between content with a default in-place circular transition.
    /// </summary>
    public class Transitioner : Selector, IZIndexController
    {
        private Point? _nextTransitionOrigin;

        static Transitioner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Transitioner), new FrameworkPropertyMetadata(typeof(Transitioner)));
        }

        /// <summary>
        /// Causes the the next slide to be displayed (affectively increments <see cref="SelectedIndex"/>).
        /// </summary>
        public static RoutedCommand MoveNextCommand = new RoutedCommand();

        /// <summary>
        /// Causes the the previous slide to be displayed (affectively decrements <see cref="SelectedIndex"/>).
        /// </summary>
        public static RoutedCommand MovePreviousCommand = new RoutedCommand();

        /// <summary>
        /// Moves to the first slide.
        /// </summary>
        public static RoutedCommand MoveFirstCommand = new RoutedCommand();

        /// <summary>
        /// Moves to the last slide.
        /// </summary>
        public static RoutedCommand MoveLastCommand = new RoutedCommand();

        public static readonly DependencyProperty AutoApplyTransitionOriginsProperty = DependencyProperty.Register(
            "AutoApplyTransitionOrigins", typeof(bool), typeof(Transitioner), new PropertyMetadata(default(bool)));

        /// <summary>
        /// If enabled, trnaisiotns origins will be applied to wipes, according to where a transition was triggered from.  For example, the mouse point where a user clicks a button.
        /// </summary>
        public bool AutoApplyTransitionOrigins
        {
            get { return (bool)GetValue(AutoApplyTransitionOriginsProperty); }
            set { SetValue(AutoApplyTransitionOriginsProperty, value); }
        }

        public static readonly DependencyProperty DefaultTransitionOriginProperty = DependencyProperty.Register(
            "DefaultTransitionOrigin", typeof(Point), typeof(Transitioner), new PropertyMetadata(new Point(0.5, 0.5)));

        public Point DefaultTransitionOrigin
        {
            get { return (Point)GetValue(DefaultTransitionOriginProperty); }
            set { SetValue(DefaultTransitionOriginProperty, value); }
        }

        public Transitioner()
        {
            CommandBindings.Add(new CommandBinding(MoveNextCommand, MoveNextHandler));
            CommandBindings.Add(new CommandBinding(MovePreviousCommand, MovePreviousHandler));
            CommandBindings.Add(new CommandBinding(MoveFirstCommand, MoveFirstHandler));
            CommandBindings.Add(new CommandBinding(MoveLastCommand, MoveLastHandler));
            AddHandler(TransitionerSlide.InTransitionFinished, new RoutedEventHandler(IsTransitionFinishedHandler));
            Loaded += (sender, args) =>
            {
                if (SelectedIndex != -1)
                    ActivateFrame(SelectedIndex, -1);
            };
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TransitionerSlide;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TransitionerSlide();
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (AutoApplyTransitionOrigins)
                _nextTransitionOrigin = GetNavigationSourcePoint(e);
            base.OnPreviewMouseLeftButtonDown(e);
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            var unselectedIndex = -1;
            if (e.RemovedItems.Count == 1)
            {
                unselectedIndex = Items.IndexOf(e.RemovedItems[0]);
            }
            var selectedIndex = 1;
            if (e.AddedItems.Count == 1)
            {
                selectedIndex = Items.IndexOf(e.AddedItems[0]);
            }

            ActivateFrame(selectedIndex, unselectedIndex);

            base.OnSelectionChanged(e);
        }

        private void IsTransitionFinishedHandler(object sender, RoutedEventArgs routedEventArgs)
        {
            foreach (var slide in Items.OfType<object>().Select(GetSlide).Where(s => s.State == TransitionerSlideState.Previous))
            {
                slide.SetCurrentValue(TransitionerSlide.StateProperty, TransitionerSlideState.None);
            }
        }

        private void MoveNextHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (AutoApplyTransitionOrigins)
                _nextTransitionOrigin = GetNavigationSourcePoint(executedRoutedEventArgs);
            SetCurrentValue(SelectedIndexProperty, Math.Min(Items.Count - 1, SelectedIndex + 1));
        }

        private void MovePreviousHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (AutoApplyTransitionOrigins)
                _nextTransitionOrigin = GetNavigationSourcePoint(executedRoutedEventArgs);
            SetCurrentValue(SelectedIndexProperty, Math.Max(0, SelectedIndex - 1));
        }

        private void MoveFirstHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (AutoApplyTransitionOrigins)
                _nextTransitionOrigin = GetNavigationSourcePoint(executedRoutedEventArgs);
            SetCurrentValue(SelectedIndexProperty, 0);
        }

        private void MoveLastHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (AutoApplyTransitionOrigins)
                _nextTransitionOrigin = GetNavigationSourcePoint(executedRoutedEventArgs);
            SetCurrentValue(SelectedIndexProperty, Items.Count - 1);
        }

        private Point? GetNavigationSourcePoint(RoutedEventArgs executedRoutedEventArgs)
        {
            var sourceElement = executedRoutedEventArgs.OriginalSource as FrameworkElement;
            if (sourceElement == null || !IsAncestorOf(sourceElement) || !IsSafePositive(ActualWidth) ||
                !IsSafePositive(ActualHeight) || !IsSafePositive(sourceElement.ActualWidth) ||
                !IsSafePositive(sourceElement.ActualHeight)) return null;

            var transitionOrigin = sourceElement.TranslatePoint(new Point(sourceElement.ActualWidth / 2, sourceElement.ActualHeight), this);
            transitionOrigin = new Point(transitionOrigin.X / ActualWidth, transitionOrigin.Y / ActualHeight);
            return transitionOrigin;
        }

        private static bool IsSafePositive(double dubz)
        {
            return !double.IsNaN(dubz) && !double.IsInfinity(dubz) && dubz > 0.0;
        }

        private TransitionerSlide GetSlide(object item)
        {
            if (this.IsItemItsOwnContainer(item))
                return (TransitionerSlide)item;

            return (TransitionerSlide)ItemContainerGenerator.ContainerFromItem(item);
        }

        private void ActivateFrame(int selectedIndex, int unselectedIndex)
        {
            if (!IsLoaded) return;

            TransitionerSlide oldSlide = null, newSlide = null;
            for (var index = 0; index < Items.Count; index++)
            {
                var slide = GetSlide(Items[index]);
                if (index == selectedIndex)
                {
                    newSlide = slide;
                    slide.SetCurrentValue(TransitionerSlide.StateProperty, TransitionerSlideState.Current);
                }
                else if (index == unselectedIndex)
                {
                    oldSlide = slide;
                    slide.SetCurrentValue(TransitionerSlide.StateProperty, TransitionerSlideState.Previous);
                }
                else
                {
                    slide.SetCurrentValue(TransitionerSlide.StateProperty, TransitionerSlideState.None);
                }
                Panel.SetZIndex(slide, 0);
            }

            if (newSlide != null)
                newSlide.Opacity = 1;
            if (oldSlide != null && newSlide != null)
            {
                var wipe = selectedIndex > unselectedIndex ? oldSlide.ForwardWipe : oldSlide.BackwardWipe;
                if (wipe != null)
                    wipe.Wipe(oldSlide, newSlide, GetTransitionOrigin(newSlide), this);
                else
                {
                    DoStack(newSlide, oldSlide);
                    oldSlide.Opacity = 0;
                }
            }
            else if (oldSlide != null || newSlide != null)
            {
                DoStack(oldSlide ?? newSlide);
                if (oldSlide != null)
                {
                    oldSlide.Opacity = 0;
                }
            }

            _nextTransitionOrigin = null;
        }

        private Point GetTransitionOrigin(TransitionerSlide slide)
        {
            if (_nextTransitionOrigin != null)
            {
                return _nextTransitionOrigin.Value;
            }

            if (slide.ReadLocalValue(TransitionerSlide.TransitionOriginProperty) != DependencyProperty.UnsetValue)
            {
                return slide.TransitionOrigin;
            }

            return DefaultTransitionOrigin;
        }

        void IZIndexController.Stack(params TransitionerSlide[] highestToLowest)
        {
            DoStack(highestToLowest);
        }

        private static void DoStack(params TransitionerSlide[] highestToLowest)
        {
            if (highestToLowest == null) return;

            var pos = highestToLowest.Length;
            foreach (var slide in highestToLowest.Where(s => s != null))
            {
                Panel.SetZIndex(slide, pos--);
            }
        }
    }
}
