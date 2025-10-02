using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирующая система ===");

        // Ввод фамилии
        Console.Write("Введите вашу фамилию: ");
        string surname = Console.ReadLine();

        // Информация о тесте
        string testName = "«Автоматизированные обучающие системы»";
        int questionCount = 5;

        Console.WriteLine($"\nДобро пожаловать, {surname}!");
        Console.WriteLine($"Название теста: {testName}");
        Console.WriteLine($"Количество вопросов: {questionCount}");
        Console.WriteLine("\nДля начала тестирования нажмите любую клавишу...");
        Console.ReadKey();
        Console.Clear();

        // Создание вопросов
        List<Question> questions = CreateQuestions();

        // Процесс тестирования
        int correctAnswers = 0;

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"Вопрос {i + 1}/{questions.Count}:");
            Console.WriteLine(questions[i].Text);
            Console.WriteLine("Варианты ответов:");

            for (int j = 0; j < questions[i].Options.Length; j++)
            {
                Console.WriteLine($"  {(char)('А' + j)}) {questions[i].Options[j]}");
            }

            Console.Write("\nВведите букву правильного ответа: ");
            string userAnswer = Console.ReadLine()?.ToUpper();

            if (userAnswer == questions[i].CorrectAnswer)
            {
                correctAnswers++;
                Console.WriteLine("✓ Правильно!\n");
            }
            else
            {
                Console.WriteLine($"✗ Неправильно. Правильный ответ: {questions[i].CorrectAnswer}\n");
            }

            if (i < questions.Count - 1)
            {
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Вывод результатов
        Console.WriteLine("=== РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ ===");
        Console.WriteLine($"Тестируемый: {surname}");
        Console.WriteLine($"Тест: {testName}");
        Console.WriteLine($"Правильных ответов: {correctAnswers} из {questionCount}");
        Console.WriteLine($"Процент выполнения: {(double)correctAnswers / questionCount * 100:0}%");

        // Простая система оценивания
        string grade = GetGrade(correctAnswers, questionCount);
        Console.WriteLine($"Оценка: {grade}");

        Console.WriteLine("\nДля выхода нажмите любую клавишу...");
        Console.ReadKey();
    }

    static List<Question> CreateQuestions()
    {
        return new List<Question>
        {
            new Question(
                "К автоматизированным обучающим системам относятся:",
                new string[] {
                    "автоматизированные архивы",
                    "информационно-расчетные системы",
                    "системы автоматизации проектирования",
                    "тренажеры и тренажерные комплексы"
                },
                "Г"
            ),
            new Question(
                "Конкретный материальный продукт, реализующий информационно-коммуникационные технологии обучения",
                new string[] {
                    "автоматизированные обучающие системы",
                    "информационные системы электронного обучения",
                    "электронный образовательный ресурс",
                    "электронный учебник"
                },
                "В"
            ),
            new Question(
                "Образовательные ресурсы, обеспечивающие возможность доступа к любой информации в локальных и глобальных сетях, удаленное интерактивное взаимодействие субъектов учебного процесса",
                new string[] {
                    "демонстрационные ЭОР",
                    "контролирующие ЭОР",
                    "коммуникативные ЭОР",
                    "диагностирующие ЭОР"
                },
                "В"
            ),
            new Question(
                "Разновидность веб-конференции, проведение онлайн-встреч или презентаций через Интернет",
                new string[] {
                    "онлайн-семинар",
                    "коучинг",
                    "вебкаст",
                    "вебинар"
                },
                "Г"
            ),
            new Question(
                "Тьютор - это",
                new string[] {
                    "видеоролик, размещенный в сети, который можно посмотреть в удобное время на выбранном вами устройстве отображения",
                    "специалист по индивидуализации в образовании, посредник между учеником и образовательной системой",
                    "форма представления содержания учебного курса, основанная на использовании современных информационных технологий",
                    "набор ИТ-сервисов, использующихся при проведении дистанционного обучения"
                },
                "Б"
            )
        };
    }

    static string GetGrade(int correct, int total)
    {
        double percentage = (double)correct / total;

        if (percentage >= 0.85) return "5 (отлично)";
        if (percentage >= 0.70) return "4 (хорошо)";
        if (percentage >= 0.50) return "3 (удовлетворительно)";
        return "2 (неудовлетворительно)";
    }
}

class Question
{
    public string Text { get; set; }
    public string[] Options { get; set; }
    public string CorrectAnswer { get; set; }

    public Question(string text, string[] options, string correctAnswer)
    {
        Text = text;
        Options = options;
        CorrectAnswer = correctAnswer;
    }
}