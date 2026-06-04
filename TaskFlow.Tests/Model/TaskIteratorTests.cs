using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskIteratorTests {
    private List<TaskFlow.Model.Task> GetTestTasks() {
      List<TaskFlow.Model.Task> tasks = new List<TaskFlow.Model.Task> {
        new TaskFlow.Model.Task("Task1", "Desc1", "2025-01-01", "High"),
        new TaskFlow.Model.Task("Task2", "Desc2", "2025-01-02", "Medium"),
        new TaskFlow.Model.Task("Task3", "Desc3", "2025-01-03", "Low")
      };

      return tasks;
    }

    [Fact]
    public void Constructor_WithEmptyList_ShouldReturnNullCurrent() {
      TaskIterator iterator = new TaskIterator(new List<TaskFlow.Model.Task>());

      Assert.Null(iterator.GetCurrent());
    }

    [Fact]
    public void GetCurrent_ShouldReturnFirstTask() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);
      TaskFlow.Model.Task current = iterator.GetCurrent();

      Assert.Equal("Task1", current.Title);
    }

    [Fact]
    public void HasNext_WhenAtFirst_ShouldReturnTrue() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);

      Assert.True(iterator.HasNext());
    }

    [Fact]
    public void HasNext_WhenAtLast_ShouldReturnFalse() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);
      _ = iterator.Next();
      _ = iterator.Next();

      Assert.False(iterator.HasNext());
    }

    [Fact]
    public void Next_ShouldMoveToNextTask() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);
      TaskFlow.Model.Task next = iterator.Next();

      Assert.Equal("Task2", next.Title);
      Assert.Equal("Task2", iterator.GetCurrent().Title);
    }

    [Fact]
    public void Previous_ShouldMoveToPreviousTask() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);
      _ = iterator.Next();
      TaskFlow.Model.Task prev = iterator.Previous();

      Assert.Equal("Task1", prev.Title);
      Assert.Equal("Task1", iterator.GetCurrent().Title);
    }

    [Fact]
    public void AssignCurrentTo_ShouldSetAssignedTo() {
      List<TaskFlow.Model.Task> tasks = GetTestTasks();
      TaskIterator iterator = new TaskIterator(tasks);

      iterator.AssignCurrentTo("Alice");
      Assert.Equal("Alice", tasks[0].AssignedTo);
    }
  }
}