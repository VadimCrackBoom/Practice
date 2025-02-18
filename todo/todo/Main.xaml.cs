using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;
using todo.Repository;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private string _username;

        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TaskModel> tasks { get; private set; }

        private UserRepository _userRepository;

        

        public Main()
        {
            InitializeComponent();
            LoadTasks();
            taskListBox.ItemsSource = tasks;

            if (UserRepository.CurrentUser != null)
            {
                username.Text = UserRepository.CurrentUser.Name;
            }
        }

        private void LoadTasks()
        {
            tasks = new ObservableCollection<TaskModel>
                {
                new TaskModel { Title = "Задача 1", DueDate = DateTime.Now.AddDays(1), IsCompleted = false, Description = "Описание задачи 1" },
                new TaskModel { Title = "Задача 2", DueDate = DateTime.Now.AddDays(2), IsCompleted = false, Description = "Описание задачи 2" },
                new TaskModel { Title = "Задача 3", DueDate = DateTime.Now.AddDays(3), IsCompleted = false, Description = "Описание задачи 3" },
                new TaskModel { Title = "Задача 4", DueDate = DateTime.Now.AddDays(4), IsCompleted = false, Description = "Описание задачи 4" },
                new TaskModel { Title = "Задача 5", DueDate = DateTime.Now.AddDays(5), IsCompleted = false, Description = "Описание задачи 5" }
                };

            if (UserRepository.CurrentUser != null)
            {
                tasks = new ObservableCollection<TaskModel>
                {

                };
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void taskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(taskListBox.SelectedItem is TaskModel selectedTask)
    {
                taskTitleTextBlock.Text = selectedTask.Title;
                taskDueDateTextBlock.Text = selectedTask.DueDate?.ToString("dd.MM.yyyy");
                taskDescriptionTextBlock.Text = selectedTask.Description;
                okButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Visible;
            }

            if (taskListBox.SelectedItem != null)
            {
                var listBoxItem = taskListBox.ItemContainerGenerator.ContainerFromItem(taskListBox.SelectedItem) as ListBoxItem;

                if (listBoxItem != null)
                {
                    listBoxItem.Background = Brushes.CornflowerBlue;
                    listBoxItem.BorderThickness = new Thickness(0);
                    listBoxItem.FocusVisualStyle = null;
                    listBoxItem.Foreground = Brushes.Black;
                }
            }

            foreach (var item in taskListBox.Items)
            {
                if (item != taskListBox.SelectedItem)
                {
                    var listBoxItem = taskListBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;

                    if (listBoxItem != null)
                    {
                        listBoxItem.Background = Brushes.Transparent;
                    }
                }
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            TaskModel selectedTask = (TaskModel)taskListBox.SelectedItem;

            selectedTask.IsCompleted = true;

            taskListBox.Items.Refresh();
        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskListBox.SelectedItem is TaskModel selectedTask)
            {
                tasks.Remove(selectedTask);
                RefreshTaskList();
                ClearTaskDetails();
            }
        }

        private void RefreshTaskList()
        {
            taskListBox.ItemsSource = tasks;
        }

        private void ClearTaskDetails()
        {
            taskTitleTextBlock.Text = string.Empty;
            taskDueDateTextBlock.Text = string.Empty;
            taskDescriptionTextBlock.Text = string.Empty;
            okButton.Visibility = Visibility.Collapsed;
            deleteButton.Visibility = Visibility.Collapsed;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Проверим, является ли кликнутый элемент StackPanel
            if (sender is StackPanel stackPanel)
            {
                // Получаем родительский ListBox
                ListBox listBox = FindAncestor<ListBox>(stackPanel);
                if (listBox != null)
                {
                    // Получаем элемент данных, связанный с выбранным StackPanel
                    var item = stackPanel.DataContext;
                    listBox.SelectedItem = item; // Устанавливаем выделенный элемент
                }
            }
        }

        // Метод для нахождения предка указанного типа
        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerTasks managerTasks = new ManagerTasks(this);
            managerTasks.Show();
        }

        public void AddTask(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Задача не может быть null.");
            }

            tasks.Add(task); // Добавляем задачу в коллекцию
            taskListBox.Items.Refresh(); // Обновляем ListBox
        }
    }
}
