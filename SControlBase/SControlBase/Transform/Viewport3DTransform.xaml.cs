using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Viewport3DTransform.xaml 的交互逻辑
    /// </summary>
    public partial class Viewport3DTransform : Window
    {
        public Viewport3DTransform()
        {
            InitializeComponent();
            SetDownloadWindowDisplayMode();
            //SetConfigViewDisplayMode();
            var turn2ConfigViewStoryboard = this.TryFindResource("Turn2ConfigViewStoryboard") as Storyboard;
            if (turn2ConfigViewStoryboard != null)
            {
                turn2ConfigViewStoryboard.Completed += (s, e1) =>
                {//动画执行完成切换展示模式

                    SetConfigViewDisplayMode();
                    SetDownloadWindowTurningMode();
                };
                turn2ConfigViewStoryboard.CurrentTimeInvalidated += (s, e1) =>
                {//动画执行时切换成翻转模式
                    SetDownloadWindowTurningMode();
                };
            };
            var turn2DownloadViewStoryboard = this.TryFindResource("Turn2DownloadViewStoryboard") as Storyboard;

            if (turn2DownloadViewStoryboard != null)
            {
                turn2DownloadViewStoryboard.Completed += (s, e1) =>
                {//动画执行完成切换展示模式

                    SetDownloadWindowDisplayMode();
                    SetConfigViewTurningMode();
                };
                turn2DownloadViewStoryboard.CurrentTimeInvalidated += (s, e1) =>
                {//动画执行时切换成翻转模式
                    SetConfigViewTurningMode();
                };
            };
        }
        private void newS_Click(object sender, RoutedEventArgs e)
        {
            var turn2ConfigViewStoryboard = this.TryFindResource("Turn2ConfigViewStoryboard") as Storyboard;
                turn2ConfigViewStoryboard.Begin();
        }

        private void setS_Click(object sender, RoutedEventArgs e)
        {
            var turn2DownloadViewStoryboard = this.TryFindResource("Turn2DownloadViewStoryboard") as Storyboard;
            turn2DownloadViewStoryboard.Begin();
           
        }
       
        /// <summary>
        /// 设置登录页面进入展示模式
        /// </summary>
        private void SetDownloadWindowDisplayMode()
        {
            //var container = DownloadWindowPart.Parent as Viewport2DVisual3D;
            //if (container == null) return;
            //container.Visual = null;
            if (FrontViewport2DVisual3D.Visual == (newS))
            {
                FrontViewport2DVisual3D.Visual = null;
            }
            DisPlayControl.Content = newS;
        }
        /// <summary>
        /// 设置配置页面进入展示模式
        /// </summary>
        private void SetConfigViewDisplayMode()
        {
            //var container = ProxyConfigViewPart.Parent as Viewport2DVisual3D;
            //if (container == null) return;
            //container.Visual = null;
            if (BackViewport2DVisual3D.Visual == (setS))
            {
                BackViewport2DVisual3D.Visual = null;
            }
            DisPlayControl.Content = setS;

        }
        /// <summary>
        /// 登录页面进入翻转模式
        /// </summary>
        private void SetDownloadWindowTurningMode()
        {
            var container = newS.Parent as UserControl;
            if (container == null) return;
            container.Content = null;
            FrontViewport2DVisual3D.Visual = newS;
        }
        /// <summary>
        /// 设置配置页进入翻转模式
        /// </summary>
        private void SetConfigViewTurningMode()
        {
            var container = setS.Parent as UserControl;
            if (container == null) return;
            container.Content = null;
            BackViewport2DVisual3D.Visual = setS;
        }
        /// <summary>
        /// 支持拖拽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisPlayControl_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
