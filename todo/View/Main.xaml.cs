using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using todo.Repository;

namespace todo.View
{
    public partial class Main : Page, INotifyPropertyChanged
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

        public ObservableCollection<TaskModel> tasks { get; set; }
        public ObservableCollection<CompletedTasks> CompletedTasks { get; set; }

        private UserRepository _userRepository;

        public static Main Current { get; private set; }

        public Main()
        {
            InitializeComponent();
            tasks = new ObservableCollection<TaskModel>();
            CompletedTasks = new ObservableCollection<CompletedTasks>();

            // Привязка данных
            taskListBox.ItemsSource = tasks;
            HistoryListBox.ItemsSource = CompletedTasks;

            if (UserRepository.CurrentUser != null)
            {
                username.Text = UserRepository.CurrentUser.Name;
            }

            Current = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Логика загрузки страницы
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void taskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (taskListBox.SelectedItem is TaskModel selectedTask)
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

                CompletedTasks.Add(new CompletedTasks
                {
                    Title = selectedTask.Title,
                    DueDate = selectedTask.DueDate,
                    Description = selectedTask.Description,
                    Category = selectedTask.Category,
                    IsCompleted = true
                });

                tasks.Remove(selectedTask);
                taskListBox.Items.Refresh();
            }
        }

        private void History_Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (HistoryListBox.Visibility == Visibility.Visible)
            {
                HistoryListBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                HistoryListBox.Visibility = Visibility.Visible;
            }
        }

        private void Tasks_Label_MouseDown(object sender, MouseButtonEventArgs e)
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
            if (sender is StackPanel stackPanel)
            {
                ListBox listBox = FindAncestor<ListBox>(stackPanel);
                if (listBox != null)
                {
                    var item = stackPanel.DataContext;
                    listBox.SelectedItem = item;
                }
            }
        }

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
            // Получаем текущую страницу (Main)
            var mainPage = this.Parent as Main;

            // Создаем экземпляр страницы ManagerTasks и передаем параметр
            var managerTasksPage = new ManagerTasks(mainPage);

            // Переход на страницу ManagerTasks
            NavigationService.Navigate(managerTasksPage);
        }

        public void AddTask(TaskModel task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Задача не может быть null.");
            }

            tasks.Add(task); // Добавляем задачу в коллекцию
        }
    }
}