using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

/************************************************************************************
    *命名空间：WpfPresentationControl.DataTest
    *文件名：  TreeDateDemo
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/29 15:04:13
    *描述： 
/************************************************************************************/

namespace WpfPresentationControl
{
    public class TreeDateDemo : INotifyPropertyChanged
    {

        private string header;
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged(nameof(Header));
            }
        }
        private bool isExpanded;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }
        private MarginData margin;
        public MarginData Margin
        {
            get { return margin; }
            set
            {
                margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }
        private ObservableCollection<TreeDateDemo> childCollection;
        public ObservableCollection<TreeDateDemo> ChildCollection
        {
            get { return childCollection; }
            set
            {
                childCollection = value;
                this.OnPropertyChanged(nameof(ChildCollection));
            }
        } 
        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        private bool isMouseLeftDown = false;
        public bool IsMouseLeftDown
        {
            get { return isMouseLeftDown; }
            set
            {
                isMouseLeftDown = value;
                OnPropertyChanged(nameof(IsMouseLeftDown));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public struct MarginData
    {
       public double LEFT;
       public double TOP;
       public double RIGHT;
       public double BOTTON;
    }
}
