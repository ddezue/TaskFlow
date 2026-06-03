using System.Collections.Generic;

namespace TaskFlow {
  public class TaskController {
    private readonly List<Task> _tasks;
    private TaskIterator _iterator;
    private readonly TaskCreator _creator;

    public TaskController() {
      _tasks = FileStorage.LoadTasks();
      _iterator = new TaskIterator(_tasks);
      _creator = new TaskCreator();
    }

    public void CreateNewTask(string title, string description, string dueDate, string priority) {
      Task newTask = new Task(title, description, dueDate, priority);
      _tasks.Add(newTask);
      _iterator = new TaskIterator(_tasks);
      FileStorage.SaveTasks(_tasks);
    }

    public void AddTemplate(string title, string description, string dueDate, string priority) {
      TaskTemplate template = new TaskTemplate(title, description, dueDate, priority);
      _creator.AddTemplate(template);
    }

    public void CreateFromTemplate(int templateIndex) {
      Task newTask = _creator.CreateFromTemplate(templateIndex);
      if (newTask != null) {
        _tasks.Add(newTask);
        _iterator = new TaskIterator(_tasks);
        FileStorage.SaveTasks(_tasks);
      }
    }

    public Task GetCurrentTask() {
      return _iterator.GetCurrent();
    }

    public void NextTask() {
      _ = _iterator.Next();
    }

    public void PreviousTask() {
      _ = _iterator.Previous();
    }

    public void AssignCurrentTaskTo(string userName) {
      _iterator.AssignCurrentTo(userName);
      FileStorage.SaveTasks(_tasks);
    }

    public void AdvanceTaskState() {
      Task current = _iterator.GetCurrent();
      if (current?.State != null) {
        current.State.Next(current);
        FileStorage.SaveTasks(_tasks);
      }
    }

    public void RevertTaskState() {
      Task current = _iterator.GetCurrent();
      if (current?.State != null) {
        current.State.Previous(current);
        FileStorage.SaveTasks(_tasks);
      }
    }

    public List<Task> GetAllTasks() {
      return _tasks;
    }
  }
}