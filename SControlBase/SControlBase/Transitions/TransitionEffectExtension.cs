using SControlBase.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

/************************************************************************************
    *命名空间：SControlBase.Transitions
    *文件名：  TransitionEffectExtension
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/21 9:56:21
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    [MarkupExtensionReturnType(typeof(TransitionEffectBase))]
    public class TransitionEffectExtension : MarkupExtension
    {
        public TransitionEffectExtension()
        {
            Kind = TransitionEffectKind.None;
        }

        public TransitionEffectExtension(TransitionEffectKind kind)
        {
            Kind = kind;
        }

        public TransitionEffectExtension(TransitionEffectKind kind, TimeSpan duration)
        {
            Kind = kind;
            Duration = duration;
        }

        [ConstructorArgument("kind")]
        public TransitionEffectKind Kind { get; set; }

        [ConstructorArgument("duration")]
        public TimeSpan? Duration { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Duration.HasValue ? new TransitionEffect(Kind, Duration.Value) : new TransitionEffect(Kind);
        }
    }
}
