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
using System.Windows.Shapes;
using todo.Repository;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для ManagerTasks.xaml
    /// </summary>
    public partial class ManagerTasks : Window
    {

        public ObservableCollection<TaskModel> tasks { get; private set; }

        private Main _main;
        public ManagerTasks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void LoadTasks()
        {
            tasks = new ObservableCollection<TaskModel>
                {
                new TaskModel { Title = "", DueDate = DateTime.Now.AddDays(1), IsCompleted = false, Description = "" }
                };
        }
    }
}
