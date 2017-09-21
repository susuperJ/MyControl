using SControlBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  HintProxyFabric
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 10:29:43
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public static partial class HintProxyFabric
    {
        private sealed class ComboBoxHintProxy : IHintProxy
        {
            private readonly ComboBox _comboBox;
            private readonly TextChangedEventHandler _comboBoxTextChangedEventHandler;

            public ComboBoxHintProxy(ComboBox comboBox)
            {
                if (comboBox == null) throw new ArgumentNullException(nameof(comboBox));

                _comboBox = comboBox;
                _comboBoxTextChangedEventHandler = ComboBoxTextChanged;
                _comboBox.AddHandler(TextBoxBase.TextChangedEvent, _comboBoxTextChangedEventHandler);
                _comboBox.SelectionChanged += ComboBoxSelectionChanged;
                _comboBox.Loaded += ComboBoxLoaded;
                _comboBox.IsVisibleChanged += ComboBoxIsVisibleChanged;
            }

            public object Content
            {
                get
                {
                    if (_comboBox.IsEditable)
                    {
                        return _comboBox.Text;
                    }

                    var comboBoxItem = _comboBox.SelectedItem as ComboBoxItem;
                    return comboBoxItem != null
                        ? comboBoxItem.Content
                        : _comboBox.SelectedItem;
                }
            }

            public bool IsLoaded => _comboBox.IsLoaded;

            public bool IsVisible => _comboBox.IsVisible;

            public bool IsEmpty()
            {
                return string.IsNullOrEmpty(_comboBox.Text);
            }

            public event EventHandler ContentChanged;

            public event EventHandler IsVisibleChanged;

            public event EventHandler Loaded;

            private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                _comboBox.Dispatcher.InvokeAsync(() => ContentChanged?.Invoke(sender, EventArgs.Empty));
            }

            private void ComboBoxIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                IsVisibleChanged?.Invoke(sender, EventArgs.Empty);
            }

            private void ComboBoxLoaded(object sender, RoutedEventArgs e)
            {
                Loaded?.Invoke(sender, EventArgs.Empty);
            }

            private void ComboBoxTextChanged(object sender, TextChangedEventArgs e)
            {
                ContentChanged?.Invoke(sender, EventArgs.Empty);
            }

            public void Dispose()
            {
                _comboBox.RemoveHandler(TextBoxBase.TextChangedEvent, _comboBoxTextChangedEventHandler);
                _comboBox.Loaded -= ComboBoxLoaded;
                _comboBox.IsVisibleChanged -= ComboBoxIsVisibleChanged;
                _comboBox.SelectionChanged -= ComboBoxSelectionChanged;
            }
        }
    }
}
