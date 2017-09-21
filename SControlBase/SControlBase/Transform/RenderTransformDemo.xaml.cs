using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SControlBase.Transform
{
    /// <summary>
    /// RenderTransformDemo.xaml 的交互逻辑
    /// </summary>
    public partial class RenderTransformDemo : Window
    {
        public RenderTransformDemo()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbto = this.TryFindResource("TransformToFront") as Storyboard;//Application.Current.Resources["TransformToMiddle"] as Storyboard;
            sbto.Begin(this);
            ConverterVisibility(false);
        }

        private void SetProxy_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbto = this.TryFindResource("TransformToReverse") as Storyboard;//Application.Current.Resources["TransformToMiddle"] as Storyboard;
            sbto.Begin(this);
            ConverterVisibility(true);
        }
        public void ConverterVisibility(bool isLogin)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(350);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    if (isLogin)
                    {
                        this.SetProxy.Visibility = Visibility.Collapsed;
                        this.login.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.SetProxy.Visibility = Visibility.Visible;
                        this.login.Visibility = Visibility.Collapsed;
                    }
                }));

            });

        }
    }
}
