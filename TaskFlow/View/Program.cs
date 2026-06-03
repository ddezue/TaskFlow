using System;
using TaskFlow.Model;

namespace TaskFlow.Controller {
  public class Program {
    private static TaskController _controller;

    public static void Main() {
      _controller = new TaskController();

      while (true) {
        Console.Clear();
        DisplayCurrentTask();
        DisplayMenu();
        string choice = Console.ReadLine();

        if (!HandleChoice(choice)) {
          break;
        }
      }
    }

    private static void DisplayCurrentTask() {
      Task current = _controller.GetCurrentTask();
      if (current == null) {
        Console.WriteLine("Нет задач. Создайте новую.");
        return;
      }

      string assignedTo = string.IsNullOrEmpty(current.AssignedTo) ? "никому" : current.AssignedTo;
      Console.WriteLine($"Текущая задача: {current.Title}");
      Console.WriteLine($"Описание: {current.Description}");
      Console.WriteLine($"Дедлайн: {current.DueDate}");
      Console.WriteLine($"Приоритет: {current.Priority}");
      Console.WriteLine($"Статус: {current.State?.GetStatus() ?? "Неизвестно"}");
      Console.WriteLine($"Назначена: {assignedTo}");
    }

    private static void DisplayMenu() {
      Console.WriteLine("\nКоманды:");
      Console.WriteLine("1 - Новая задача");
      Console.WriteLine("2 - Добавить шаблон");
      Console.WriteLine("3 - Создать из шаблона");
      Console.WriteLine("4 - Следующая задача");
      Console.WriteLine("5 - Предыдущая задача");
      Console.WriteLine("6 - Назначить текущему пользователю");
      Console.WriteLine("7 - Следующий статус");
      Console.WriteLine("8 - Предыдущий статус");
      Console.WriteLine("0 - Выход");
      Console.WriteLine();
    }

    private static bool HandleChoice(string choice) {
      switch (choice) {
        case "0":
          return false;
        case "1":
          CreateNewTask();
          break;
        case "2":
          AddTemplate();
          break;
        case "3":
          CreateFromTemplate();
          break;
        case "4":
          _controller.NextTask();
          break;
        case "5":
          _controller.PreviousTask();
          break;
        case "6":
          _controller.AssignCurrentTaskTo("Текущий пользователь");
          break;
        case "7":
          _controller.AdvanceTaskState();
          break;
        case "8":
          _controller.RevertTaskState();
          break;
        default:
          break;
      }
      return true;
    }

    private static void CreateNewTask() {
      Console.WriteLine();
      Console.Write("Название: ");
      string title = Console.ReadLine();
      Console.Write("Описание: ");
      string desc = Console.ReadLine();
      Console.Write("Дедлайн: ");
      string date = Console.ReadLine();
      Console.Write("Приоритет: ");
      string priority = Console.ReadLine();
      _controller.CreateNewTask(title, desc, date, priority);
    }

    private static void AddTemplate() {
      Console.Write("Название шаблона: ");
      string title = Console.ReadLine();
      Console.Write("Описание: ");
      string desc = Console.ReadLine();
      Console.Write("Дедлайн: ");
      string date = Console.ReadLine();
      Console.Write("Приоритет: ");
      string priority = Console.ReadLine();
      _controller.AddTemplate(title, desc, date, priority);
      Console.WriteLine("Шаблон добавлен");
      _ = Console.ReadKey();
    }

    private static void CreateFromTemplate() {
      Console.Write("Индекс шаблона (0): ");
      if (int.TryParse(Console.ReadLine(), out int index)) {
        _controller.CreateFromTemplate(index);
      }
    }
  }
}