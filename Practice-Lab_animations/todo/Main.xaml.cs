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
        public ObservableCollection<CompletedTasks> CompletedTasks { get; private set; }

        private UserRepository _userRepository;

        

        public Main()
        {
            InitializeComponent();
            LoadTasks();
            taskListBox.ItemsSource = tasks;
            CompletedTasks = new ObservableCollection<CompletedTasks>();
            HistoryListBox.ItemsSource = CompletedTasks;

            if (UserRepository.CurrentUser != null)
            {
                username.Text = UserRepository.CurrentUser.Name;
            }
        }

        private void LoadTasks()
        {
            tasks = new ObservableCollection<TaskModel>
                {
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
        }

        private void HistoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HistoryListBox.SelectedItem is CompletedTasks selectedTask)
            {
                // Обновляем текстовые блоки с информацией о задаче
                taskTitleTextBlock.Text = selectedTask.Title;
                taskDueDateTextBlock.Text = selectedTask.DueDate?.ToString("dd.MM.yyyy");
                taskDescriptionTextBlock.Text = selectedTask.Description;
            }

            if (HistoryListBox.SelectedItem != null)
{
                var listBoxItem = HistoryListBox.ItemContainerGenerator.ContainerFromItem(HistoryListBox.SelectedItem) as ListBoxItem;

                if (listBoxItem != null)
                {
                    okButton.Visibility = Visibility.Collapsed;
                    deleteButton.Visibility = Visibility.Collapsed;


                }
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskListBox.SelectedItem is TaskModel selectedTask)
            {
                selectedTask.IsCompleted = true;

                // Перемещаем задачу в историю
                CompletedTasks.Add(new CompletedTasks
                {
                    Title = selectedTask.Title,
                    DueDate = selectedTask.DueDate,
                    Description = selectedTask.Description,
                    Category = selectedTask.Category,
                    IsCompleted = true
                });

                // Удаляем задачу из списка текущих задач
                tasks.Remove(selectedTask);

                // Обновляем ListBox
                taskListBox.Items.Refresh();
            }
        }

        private void History_Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Переключаем видимость HistoryListBox
            if (HistoryListBox.Visibility == Visibility.Visible)
            {
                HistoryListBox.Visibility = Visibility.Collapsed; // Скрываем
            }
            else
            {
                HistoryListBox.Visibility = Visibility.Visible; // Показываем
            }
        }

        private void Tasks_Label_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (taskListBox.Visibility == Visibility.Visible)
            {
                taskListBox.Visibility = Visibility.Collapsed;
            }

            else
            {
                taskListBox.Visibility = Visibility.Visible;
            }
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
