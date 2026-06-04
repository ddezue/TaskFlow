using System.Collections.Generic;
using System.IO;
using TaskFlow.Model;

namespace TaskFlow.Controller {
  public static class FileStorage {
    private static readonly string s_filePath = "tasks.txt";

    public static void SaveTasks(List<Task> tasks) {
      List<string> lines = new List<string>();

      foreach (Task task in tasks) {
        string statusName = task.State.GetStatus();
        string line = $"{task.Id}|{task.Title}|{task.Description}|{task.DueDate}|{task.Priority}|{statusName}|{task.AssignedTo}";
        lines.Add(line);
      }

      File.WriteAllLines(s_filePath, lines);
    }

    public static List<Task> LoadTasks() {
      List<Task> tasks = new List<Task>();

      if (!File.Exists(s_filePath)) {
        return tasks;
      }

      string[] lines = File.ReadAllLines(s_filePath);

      foreach (string line in lines) {
        string[] parts = line.Split('|');

        if (parts.Length == 7) {
          Task task = new Task(parts[1], parts[2], parts[3], parts[4]) {
            Id = parts[0],
            AssignedTo = parts[6]
          };

          switch (parts[5]) {
            case "Новая":
              task.State = new NewState();
              break;
            case "В работе":
              task.State = new InProgressState();
              break;
            case "На проверке":
              task.State = new ReviewState();
              break;
            case "Завершена":
              task.State = new DoneState();
              break;
            default:
              task.State = new NewState();
              break;
          }

          tasks.Add(task);
        }
      }

      return tasks;
    }
  }
}