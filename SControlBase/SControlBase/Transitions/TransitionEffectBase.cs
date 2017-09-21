using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

/************************************************************************************
    *命名空间：SControlBase.Transitions
    *文件名：  TransitionEffectBase
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/20 17:37:40
    *描述： 
/************************************************************************************/

namespace SControlBase.Transitions
{
    public abstract class TransitionEffectBase : FrameworkElement, ITransitionEffect
    {
        public abstract Timeline Build<TSubject>(TSubject effectSubject) where TSubject : FrameworkElement, ITransitionEffectSubject;
    }
}
