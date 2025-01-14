using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace todo
{
    public partial class TasksWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; private set; }
        private bool showCompletedTasks = false; // Флаг для отслеживания отображаемых задач

        public TasksWindow()
        {
            InitializeComponent();

            Tasks = new ObservableCollection<TaskItem>();
            TaskList.ItemsSource = Tasks; // Изначально отображаем все задачи
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog();

            if (addTaskWindow.IsTaskCreated && !string.IsNullOrWhiteSpace(addTaskWindow.TaskTitle))
            {
                var newTask = new TaskItem
                {
                    Title = addTaskWindow.TaskTitle,
                    IsComplete = false,
                    Description = addTaskWindow.TaskDescription
                };
                Tasks.Add(newTask);
                UpdateTaskList(); // Обновляем список после добавления задачи
            }
        }

        private void TaskList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                TaskDetails.Text = selectedTask.Description;
            }
            else
            {
                TaskDetails.Text = string.Empty;
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                // Удаляем только из основной коллекции задач
                Tasks.Remove(selectedTask);
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для её удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MarkTaskAsComplete(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                selectedTask.IsComplete = true; // отмечаем задачу как завершенную
                UpdateTaskList(); // Обновляем содержимое списка
            }
        }

        private void ShowCompletedTasks_Click(object sender, RoutedEventArgs e)
        {
            showCompletedTasks = true; // Устанавливаем флаг для показа завершенных задач
            UpdateTaskList();
        }

        private void TasksClass_Click(object sender, RoutedEventArgs e)
        {
            showCompletedTasks = false; // Устанавливаем флаг для показа невыполненных задач
            UpdateTaskList();
        }

        private void HistoryTasks_Click(object sender, RoutedEventArgs e)
        {
            showCompletedTasks = true; // Устанавливаем флаг для показа завершенных задач
            UpdateTaskList();
        }

        private void UpdateTaskList()
        {
            // Обновляем источник данных в зависимости от выбранного значения флага showCompletedTasks
            if (showCompletedTasks)
            {
                TaskList.ItemsSource = new ObservableCollection<TaskItem>(Tasks.Where(t => t.IsComplete));
            }
            else
            {
                TaskList.ItemsSource = new ObservableCollection<TaskItem>(Tasks.Where(t => !t.IsComplete));
            }
        }
    }

    public class TaskItem : System.ComponentModel.INotifyPropertyChanged
    {
        private bool isComplete;
        public bool IsComplete
        {
            get => isComplete;
            set
            {
                isComplete = value;
                OnPropertyChanged(nameof(IsComplete));
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
