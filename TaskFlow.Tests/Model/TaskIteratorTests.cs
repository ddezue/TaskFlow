using System.Collections.Generic;
using Xunit;
using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskIteratorTests {
    private List<Task> GetTestTasks() {
      List<Task> tasks;

      tasks = new List<Task> {
        new Task("Task1", "Desc1", "2025-01-01", "High"),
        new Task("Task2", "Desc2", "2025-01-02", "Medium"),
        new Task("Task3", "Desc3", "2025-01-03", "Low")
      };

      return tasks;
    }

    [Fact]
    public void Constructor_WithEmptyList_ShouldReturnNullCurrent() {
      TaskIterator iterator;

      iterator = new TaskIterator(new List<Task>());

      Assert.Null(iterator.GetCurrent());
    }

    [Fact]
    public void GetCurrent_ShouldReturnFirstTask() {
      List<Task> tasks;
      TaskIterator iterator;
      Task current;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);
      current = iterator.GetCurrent();

      Assert.Equal("Task1", current.Title);
    }

    [Fact]
    public void HasNext_WhenAtFirst_ShouldReturnTrue() {
      List<Task> tasks;
      TaskIterator iterator;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);

      Assert.True(iterator.HasNext());
    }

    [Fact]
    public void HasNext_WhenAtLast_ShouldReturnFalse() {
      List<Task> tasks;
      TaskIterator iterator;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);
      iterator.Next();
      iterator.Next();

      Assert.False(iterator.HasNext());
    }

    [Fact]
    public void Next_ShouldMoveToNextTask() {
      List<Task> tasks;
      TaskIterator iterator;
      Task next;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);
      next = iterator.Next();

      Assert.Equal("Task2", next.Title);
      Assert.Equal("Task2", iterator.GetCurrent().Title);
    }

    [Fact]
    public void Previous_ShouldMoveToPreviousTask() {
      List<Task> tasks;
      TaskIterator iterator;
      Task prev;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);
      iterator.Next();
      prev = iterator.Previous();

      Assert.Equal("Task1", prev.Title);
      Assert.Equal("Task1", iterator.GetCurrent().Title);
    }

    [Fact]
    public void AssignCurrentTo_ShouldSetAssignedTo() {
      List<Task> tasks;
      TaskIterator iterator;

      tasks = GetTestTasks();
      iterator = new TaskIterator(tasks);

      iterator.AssignCurrentTo("Alice");
      Assert.Equal("Alice", tasks[0].AssignedTo);
    }
  }
}