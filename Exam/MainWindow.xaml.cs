using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employ;
        Employee op = new Employee();
        public MainWindow()
        {
            InitializeComponent();
            employ = new ObservableCollection<Employee>();
            dataGrid.ItemsSource = employ;
        }

        private void Next_Clik(object sender, RoutedEventArgs e)
        {
            GridView window = new GridView(employ);
            window.Show();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            employ.Add(new Employee{Id=0, FullName = "name", Position = "position",});
            //emp = new Employee { Id = 0, FullName = "your name", Position = "your position" };

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                employ.Remove((Employee)dataGrid.SelectedItem);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Employee>));
            using(FileStream fs= new FileStream("employee.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs,employ);
            }
          
        }
    }
}
