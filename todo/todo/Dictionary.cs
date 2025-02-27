using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo
{
     public class Dictionary
     {
            // Создаем словарь для хранения информации об элементах кода
        Dictionary<string, string> codeElements = new Dictionary<string, string>()
        {
            // Поля и свойства
            { "_username", "string - поле для хранения имени пользователя." },
            { "UserName", "string - свойство для доступа к _username с уведомлением об изменении." },
            { "tasks", "ObservableCollection<TaskModel> - коллекция текущих задач." },
            { "CompletedTasks", "ObservableCollection<CompletedTasks> - коллекция завершенных задач." },
            { "_userRepository", "UserRepository - репозиторий для работы с данными пользователя." },

            // Элементы управления
            { "taskListBox", "ListBox - элемент управления для отображения текущих задач." },
            { "HistoryListBox", "ListBox - элемент управления для отображения завершенных задач." },
            { "username", "TextBlock - элемент для отображения имени пользователя." },
            { "taskTitleTextBlock", "TextBlock - элемент для отображения заголовка задачи." },
            { "taskDueDateTextBlock", "TextBlock - элемент для отображения даты выполнения задачи." },
            { "taskDescriptionTextBlock", "TextBlock - элемент для отображения описания задачи." },
            { "okButton", "Button - кнопка для завершения задачи." },
            { "deleteButton", "Button - кнопка для удаления задачи." },

            // Методы
            { "LoadTasks", "void - метод для загрузки задач." },
            { "Window_Loaded", "void - обработчик события загрузки окна." },
            { "taskListBox_SelectionChanged", "void - обработчик события изменения выбора в taskListBox." },
            { "HistoryListBox_SelectionChanged", "void - обработчик события изменения выбора в HistoryListBox." },
            { "okButton_Click", "void - обработчик нажатия кнопки okButton." },
            { "deleteButton_Click", "void - обработчик нажатия кнопки deleteButton." },
            { "RefreshTaskList", "void - метод для обновления списка задач." },
            { "ClearTaskDetails", "void - метод для очистки деталей задачи." },
            { "StackPanel_MouseDown", "void - обработчик нажатия на StackPanel." },
            { "FindAncestor", "T - метод для поиска родительского элемента указанного типа." },
            { "Button_Click", "void - обработчик нажатия кнопки для открытия окна управления задачами." },
            { "AddTask", "void - метод для добавления новой задачи в коллекцию." },

            // Классы
            { "TaskModel", "Класс - модель данных для задачи." },
            { "CompletedTasks", "Класс - модель данных для завершенной задачи." },
            { "UserRepository", "Класс - репозиторий для работы с данными пользователя." },
            { "ManagerTasks", "Класс - окно для управления задачами." },

            // События
            { "PropertyChanged", "Событие - для уведомления об изменении свойств." },

            // Прочее
            { "OnPropertyChanged", "void - метод для вызова события PropertyChanged." },

            // Регистрация
            { "userRepository", "UserRepository - репозиторий для работы с данными пользователя." },
            { "nameTB", "TextBox - поле для ввода имени пользователя." },
            { "emailTB", "TextBox - поле для ввода электронной почты." },
            { "passwordTB", "TextBox - поле для ввода пароля." },
            { "againPasswordTB", "TextBox - поле для повторного ввода пароля." },
            { "RemoveText", "void - метод для очистки текста в TextBox при фокусе." },
            { "AddText", "void - метод для добавления текста в TextBox при потере фокуса." },
            { "Button_Click", "void - обработчик нажатия кнопки для перехода к окну авторизации." },
            { "Button_Click_1", "void - обработчик нажатия кнопки для регистрации пользователя." },

            // Авторизация
            { "emailTB", "TextBox - поле для ввода электронной почты." },
            { "passwordTB", "TextBox - поле для ввода пароля." },
            { "RemoveText", "void - метод для очистки текста в TextBox при фокусе." },
            { "AddText", "void - метод для добавления текста в TextBox при потере фокуса." },
            { "Button_Click", "void - обработчик нажатия кнопки для перехода к окну регистрации." },
            { "Button_Click_1", "void - обработчик нажатия кнопки для авторизации пользователя." },

            // Общие элементы
            { "UserRepository", "Класс - репозиторий для работы с данными пользователя." },
            { "LogIn", "Класс - окно авторизации." },
            { "Registration", "Класс - окно регистрации." },
            { "MainEmpty", "Класс - главное окно приложения после авторизации." },


        };
     }
}
