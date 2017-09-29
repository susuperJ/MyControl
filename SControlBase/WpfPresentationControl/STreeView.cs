using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentationControl
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfPresentationControl"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfPresentationControl;assembly=WpfPresentationControl"
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
    ///     <MyNamespace:STreeView/>
    ///
    /// </summary>
    public class STreeView : TreeView
    {
        private TreeDateDemo _selectItem;
        private TreeViewItem _targetItem;
        private StackPanel _moveSnapshoot;
        ObservableCollection<TreeDateDemo> _coll;
        private bool _IsDown=false;
        static STreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(STreeView), new FrameworkPropertyMetadata(typeof(STreeView)));
        }
        public static readonly DependencyProperty SelectTextProperty = DependencyProperty.Register(nameof(SelectText), typeof(string),
            typeof(STreeView), new PropertyMetadata(default(string)));
        public string SelectText
        {
            get { return (string)this.GetValue(SelectTextProperty); }
            set
            {
                this.SetValue(SelectTextProperty, value);
            }
        }
        public static readonly DependencyProperty IsSnapshootVisibilityProperty = DependencyProperty.Register(nameof(IsSnapshootVisibility)
            ,typeof(bool),typeof(STreeView),new PropertyMetadata(false));
        public bool IsSnapshootVisibility
        {
            get { return (bool)this.GetValue(IsSnapshootVisibilityProperty); }
            set
            {
                this.SetValue(IsSnapshootVisibilityProperty, value);
            }
        }
        public override void OnApplyTemplate()
        {
            _coll = this.ItemsSource as ObservableCollection<TreeDateDemo>;
            _moveSnapshoot = GetTemplateChild("Snapshoot") as StackPanel;
            base.OnApplyTemplate();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            var d= e.Source;
            base.OnMouseLeftButtonDown(e);
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            //if (_IsDown)
            //{
            //    _selectItem.IsSelected = false;
            //    this._selectItem = null;
            //}
            base.OnMouseLeave(e);
        }
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            if (_selectItem == null)
            {
                _selectItem = e.NewValue as TreeDateDemo;
                _IsDown = true;
                _moveSnapshoot.Visibility = Visibility.Visible;
                this.SelectText = _selectItem.Header;
                foreach (var item in _coll)
                {
                    if(item!=_selectItem)
                    item.IsMouseLeftDown = true;
                }
            }
            base.OnSelectedItemChanged(e);
        }
       
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (_selectItem != null)
            {
                _IsDown = false;
                FrameworkElement viewItem = Mouse.DirectlyOver as FrameworkElement;
                TreeViewItem it = null;
                GetItemView(viewItem, ref it);
                if (it == null)
                    return;
                TreeDateDemo target = it.DataContext as TreeDateDemo;
                if (target != null&&target!=_selectItem)
                {
                    int odleIndex = _coll.IndexOf(_selectItem);
                    int newIndex = _coll.IndexOf(target);
                    _coll.Move(odleIndex,newIndex );
                }
                _selectItem.IsSelected = false;
                foreach (var item in _coll)
                {
                    item.IsMouseLeftDown = false;
                }
                this._selectItem = null;
            }
            base.OnMouseLeftButtonUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_IsDown)
            {
                this._moveSnapshoot.RenderTransform = new TranslateTransform(e.GetPosition(null).X, e.GetPosition(null).Y);
            }
            base.OnMouseMove(e);
        }
        private void GetItemView(FrameworkElement obj,ref TreeViewItem treeItem)
        {
           if (obj == null)
                return;
           FrameworkElement view = obj.TemplatedParent as FrameworkElement;
           treeItem = view as TreeViewItem;
            if (treeItem == null)
            {
                GetItemView(view,ref treeItem);
            }
           

        }
    }
}
