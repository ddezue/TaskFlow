using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskFlow {
  public static class FileStorage {
    private static readonly string s_filePath = "tasks.json";

    public static void SaveTasks(List<Task> tasks) {
      string json = JsonSerializer.Serialize(tasks);
      File.WriteAllText(s_filePath, json);
    }

    public static List<Task> LoadTasks() {
      if (!File.Exists(s_filePath)) {
        return new List<Task>();
      }
      string json = File.ReadAllText(s_filePath);
      return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
    }
  }
}