using System.Collections.Generic;

namespace TaskFlow.Model {
  public class TaskCreator {
    private readonly List<TaskTemplate> _templates;

    public TaskCreator() {
      _templates = new List<TaskTemplate>();
    }

    public void AddTemplate(TaskTemplate template) {
      _templates.Add(template);
    }

    public Task CreateFromTemplate(int templateIndex) {
      return templateIndex < 0 || templateIndex >= _templates.Count ? null : _templates[templateIndex].CreateTask();
    }

    public Task CloneTask(Task original) {
      return original.Clone();
    }
  }
}