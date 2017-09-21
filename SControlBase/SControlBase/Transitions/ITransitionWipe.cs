using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SControlBase.Transitions
{
    public interface ITransitionWipe
    {
        void Wipe(TransitionerSlide fromSlide, TransitionerSlide toSlide, Point origin, IZIndexController zIndexController);
    }
}
