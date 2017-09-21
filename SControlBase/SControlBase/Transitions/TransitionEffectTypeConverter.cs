using SControlBase.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xaml;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  TransitionEffectTypeConverter
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/20 17:35:51
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public class TransitionEffectTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || typeof(TransitionEffectKind).IsAssignableFrom(sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            TransitionEffectBase transitionEffect = null;

            var stringValue = value as string;
            if (stringValue != null)
            {
                TransitionEffectKind effectKind;
                if (Enum.TryParse(stringValue, out effectKind))
                    transitionEffect = new TransitionEffect(effectKind);
            }
            else
                transitionEffect = value as TransitionEffectBase;

            if (transitionEffect == null)
                throw new XamlParseException($"Could not parse to type {typeof(TransitionEffectKind).FullName} or {typeof(TransitionEffectBase).FullName}.");

            return transitionEffect; 
        }
    }
}
