using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SControlBase.Transitions
{
    public interface IZIndexController
    {
        void Stack(params TransitionerSlide[] highestToLowest);
    }
}
