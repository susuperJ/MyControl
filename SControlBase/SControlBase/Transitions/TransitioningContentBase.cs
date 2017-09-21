using SControlBase.Transitions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    ///     <MyNamespace:TransitioningContentBase/>
    ///
    /// </summary>
    public class TransitioningContentBase : ContentControl, ITransitionEffectSubject
    {
        public const string MatrixTransformPartName = "PART_MatrixTransform";
        public const string RotateTransformPartName = "PART_RotateTransform";
        public const string ScaleTransformPartName = "PART_ScaleTransform";
        public const string SkewTransformPartName = "PART_SkewTransform";
        public const string TranslateTransformPartName = "PART_TranslateTransform";

        private MatrixTransform _matrixTransform;
        private RotateTransform _rotateTransform;
        private ScaleTransform _scaleTransform;
        private SkewTransform _skewTransform;
        private TranslateTransform _translateTransform;

        private bool _isOpeningEffectPending = false;

        static TransitioningContentBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TransitioningContentBase), new FrameworkPropertyMetadata(typeof(TransitioningContentBase)));
        }

        public TransitioningContentBase()
        {
            NameScope.SetNameScope(this, new NameScope());
        }

        public override void OnApplyTemplate()
        {
            _matrixTransform = GetTemplateChild(MatrixTransformPartName) as MatrixTransform;
            _rotateTransform = GetTemplateChild(RotateTransformPartName) as RotateTransform;
            _scaleTransform = GetTemplateChild(ScaleTransformPartName) as ScaleTransform;
            _skewTransform = GetTemplateChild(SkewTransformPartName) as SkewTransform;
            _translateTransform = GetTemplateChild(TranslateTransformPartName) as TranslateTransform;

            UnregisterNames(MatrixTransformPartName, RotateTransformPartName, ScaleTransformPartName, SkewTransformPartName, TranslateTransformPartName);
            if (_matrixTransform != null)
                RegisterName(MatrixTransformPartName, _matrixTransform);
            if (_rotateTransform != null)
                RegisterName(RotateTransformPartName, _rotateTransform);
            if (_scaleTransform != null)
                RegisterName(ScaleTransformPartName, _scaleTransform);
            if (_skewTransform != null)
                RegisterName(SkewTransformPartName, _skewTransform);
            if (_translateTransform != null)
                RegisterName(TranslateTransformPartName, _translateTransform);

            base.OnApplyTemplate();

            RunOpeningEffects();
        }

        private void UnregisterNames(params string[] names)
        {
            foreach (var name in names.Where(n => FindName(n) != null))
            {
                UnregisterName(name);
            }
        }

        public static readonly DependencyProperty OpeningEffectProperty = DependencyProperty.Register("OpeningEffect", typeof(TransitionEffectBase), typeof(TransitioningContentBase), new PropertyMetadata(default(TransitionEffectBase)));

        /// <summary>
        /// Gets or sets the transition to run when the content is loaded and made visible.
        /// </summary>
        [TypeConverter(typeof(TransitionEffectTypeConverter))]
        public TransitionEffectBase OpeningEffect
        {
            get { return (TransitionEffectBase)GetValue(OpeningEffectProperty); }
            set { SetValue(OpeningEffectProperty, value); }
        }

        public static readonly DependencyProperty OpeningEffectsOffsetProperty = DependencyProperty.Register(
            "OpeningEffectsOffset", typeof(TimeSpan), typeof(TransitioningContentBase), new PropertyMetadata(default(TimeSpan)));

        /// <summary>
        /// Delay offset to be applied to all opening effect transitions.
        /// </summary>
        public TimeSpan OpeningEffectsOffset
        {
            get { return (TimeSpan)GetValue(OpeningEffectsOffsetProperty); }
            set { SetValue(OpeningEffectsOffsetProperty, value); }
        }

        /// <summary>
        /// Allows multiple transition effects to be combined and run upon the content loading or being made visible.
        /// </summary>
        public ObservableCollection<TransitionEffectBase> OpeningEffects { get; } = new ObservableCollection<TransitionEffectBase>();

        string ITransitionEffectSubject.MatrixTransformName => MatrixTransformPartName;

        string ITransitionEffectSubject.RotateTransformName => RotateTransformPartName;

        string ITransitionEffectSubject.ScaleTransformName => ScaleTransformPartName;

        string ITransitionEffectSubject.SkewTransformName => SkewTransformPartName;

        string ITransitionEffectSubject.TranslateTransformName => TranslateTransformPartName;

        TimeSpan ITransitionEffectSubject.Offset => OpeningEffectsOffset;

        protected virtual void RunOpeningEffects()
        {
            if (!IsLoaded || _matrixTransform == null)
            {
                _isOpeningEffectPending = true;
                return;
            }
            _isOpeningEffectPending = false;

            var storyboard = new Storyboard();
            var openingEffect = OpeningEffect?.Build(this);
            if (openingEffect != null)
                storyboard.Children.Add(openingEffect);
            foreach (var effect in OpeningEffects.Select(e => e.Build(this)).Where(tl => tl != null))
            {
                storyboard.Children.Add(effect);
            }

            storyboard.Begin(this);
        }
    }
}
