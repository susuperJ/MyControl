using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfPresentationControl;

namespace SControlBase
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DateDemo();
            ObservableCollection<TreeDateDemo> Collection = new ObservableCollection<TreeDateDemo>
            {
                new TreeDateDemo {  Header="11",
                    ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},

                new TreeDateDemo {Header="22",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo { Header="33",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo {  Header="44",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo {Header="55",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo { Header="66",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo {  Header="77",
                    ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo {Header="88",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}},
                new TreeDateDemo { Header="99",
                ChildCollection =new ObservableCollection<TreeDateDemo> {  new TreeDateDemo {  Header="11"},
                        new TreeDateDemo {Header="22"},new TreeDateDemo { Header="33"},
                        new TreeDateDemo {  Header="44"},new TreeDateDemo {Header="55"},new TreeDateDemo { Header="66"},
                        new TreeDateDemo {  Header="77"},new TreeDateDemo {Header="88"},new TreeDateDemo { Header="99"}}}
            };

            this.treeItem.ItemsSource = Collection;
        }
       
       

    }
    
    public class DateDemo : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
