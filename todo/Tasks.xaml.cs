using System.Collections.ObjectModel;
using System.Windows;

namespace todo
{
    public partial class TasksWindow : Window
    {
        // Инициализация ObservableCollection для хранения списка задач
        public ObservableCollection<TaskItem> Tasks { get; private set; }

        public TasksWindow()
        {
            InitializeComponent();

            // Инициализация ObservableCollection
            Tasks = new ObservableCollection<TaskItem>
            {

            };

            // Привязка коллекции задач к ListBox
            TaskList.ItemsSource = Tasks;
        }

        // Обработчик нажатия кнопки "Добавить задачу"
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и открываем окно добавления задачи
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog();

            // Проверка, создана ли задача и что заголовок не пустой
            if (addTaskWindow.IsTaskCreated && !string.IsNullOrWhiteSpace(addTaskWindow.TaskTitle))
            {
                var newTask = new TaskItem
                {
                    Title = addTaskWindow.TaskTitle,
                    IsComplete = false,
                    Description = addTaskWindow.TaskDescription
                };
                Tasks.Add(newTask); // Добавляем новую задачу в коллекцию
            }
        }

        // Обработчик изменения выбора задачи в списке
        private void TaskList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Если выбрана задача, показываем её описание
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                TaskDetails.Text = selectedTask.Description; // выводим описание выбранной задачи
            }
            else
            {
                TaskDetails.Text = string.Empty; // очищаем текст, если нет выбранной задачи
            }
        }
    }

    // Класс для представления задачи
    public class TaskItem : System.ComponentModel.INotifyPropertyChanged
    {
        private bool isComplete;
        public bool IsComplete
        {
            get => isComplete;
            set
            {

                isComplete = value;
                OnPropertyChanged(nameof(IsComplete)); // уведомляем об изменении свойства
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
