using SControlBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  HintProxyFabric
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 10:34:39
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public static partial class HintProxyFabric
    {
        private sealed class PasswordBoxHintProxy : IHintProxy
        {
            private readonly PasswordBox _passwordBox;

            public bool IsEmpty() => string.IsNullOrEmpty(_passwordBox.Password);

            public object Content => _passwordBox.Password;

            public bool IsLoaded => _passwordBox.IsLoaded;

            public bool IsVisible => _passwordBox.IsVisible;

            public event EventHandler ContentChanged;
            public event EventHandler IsVisibleChanged;
            public event EventHandler Loaded;

            public PasswordBoxHintProxy(PasswordBox passwordBox)
            {
                if (passwordBox == null) throw new ArgumentNullException(nameof(passwordBox));

                _passwordBox = passwordBox;
                _passwordBox.PasswordChanged += PasswordBoxPasswordChanged;
                _passwordBox.Loaded += PasswordBoxLoaded;
                _passwordBox.IsVisibleChanged += PasswordBoxIsVisibleChanged;
            }

            private void PasswordBoxIsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
            {
                IsVisibleChanged?.Invoke(this, EventArgs.Empty);
            }

            private void PasswordBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
            {
                Loaded?.Invoke(this, EventArgs.Empty);
            }

            private void PasswordBoxPasswordChanged(object sender, System.Windows.RoutedEventArgs e)
            {
                ContentChanged?.Invoke(this, EventArgs.Empty);
            }

            public void Dispose()
            {
                _passwordBox.PasswordChanged -= PasswordBoxPasswordChanged;
                _passwordBox.Loaded -= PasswordBoxLoaded;
                _passwordBox.IsVisibleChanged -= PasswordBoxIsVisibleChanged;
            }

        }
    }
}
