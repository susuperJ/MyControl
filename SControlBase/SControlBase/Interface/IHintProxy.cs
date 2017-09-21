using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SControlBase.Interface
{
   public interface IHintProxy:IDisposable
    {
        bool IsEmpty();

        [Obsolete]
        object Content { get; }

        bool IsLoaded { get; }

        bool IsVisible { get; }

        event EventHandler ContentChanged;

        event EventHandler IsVisibleChanged;

        event EventHandler Loaded;
    }
}
