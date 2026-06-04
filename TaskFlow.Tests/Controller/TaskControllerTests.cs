using System.IO;
using Xunit;
using TaskFlow.Controller;
using TaskFlow.Model;

namespace TaskFlow.Tests.Controller {
  public class TaskControllerTests {
    private readonly string _testFilePath = "test_tasks.txt";

    public TaskControllerTests() {
      if (File.Exists(_testFilePath)) {
        File.Delete(_testFilePath);
      }
    }

    [Fact]
    public void CreateNewTask_ShouldAddTask() {
      TaskController controller;
      Task task;

      controller = new TaskController();
      controller.CreateNewTask("Test", "Desc", "2025-12-31", "High");
      task = controller.GetCurrentTask();

      Assert.NotNull(task);
      Assert.Equal("Test", task.Title);
    }

    [Fact]
    public void NextTask_ShouldChangeCurrentTask() {
      TaskController controller;
      Task current;

      controller = new TaskController();
      controller.CreateNewTask("Task1", "Desc1", "2025-01-01", "High");
      controller.CreateNewTask("Task2", "Desc2", "2025-01-02", "Medium");
      controller.NextTask();
      current = controller.GetCurrentTask();

      Assert.Equal("Task2", current.Title);
    }

    [Fact]
    public void PreviousTask_ShouldChangeCurrentTask() {
      TaskController controller;
      Task current;

      controller = new TaskController();
      controller.CreateNewTask("Task1", "Desc1", "2025-01-01", "High");
      controller.CreateNewTask("Task2", "Desc2", "2025-01-02", "Medium");
      controller.NextTask();
      controller.PreviousTask();
      current = controller.GetCurrentTask();

      Assert.Equal("Task1", current.Title);
    }

    [Fact]
    public void AdvanceTaskState_ShouldChangeState() {
      TaskController controller;
      Task task;

      controller = new TaskController();
      controller.CreateNewTask("Test", "Desc", "2025-12-31", "High");
      task = controller.GetCurrentTask();

      Assert.IsType<NewState>(task.State);

      controller.AdvanceTaskState();
      Assert.IsType<InProgressState>(task.State);
    }

    [Fact]
    public void RevertTaskState_ShouldChangeState() {
      TaskController controller;
      Task task;

      controller = new TaskController();
      controller.CreateNewTask("Test", "Desc", "2025-12-31", "High");
      controller.AdvanceTaskState();
      task = controller.GetCurrentTask();

      Assert.IsType<InProgressState>(task.State);

      controller.RevertTaskState();
      Assert.IsType<NewState>(task.State);
    }

    [Fact]
    public void AssignCurrentTaskTo_ShouldSetAssignee() {
      TaskController controller;
      Task task;

      controller = new TaskController();
      controller.CreateNewTask("Test", "Desc", "2025-12-31", "High");
      controller.AssignCurrentTaskTo("Bob");
      task = controller.GetCurrentTask();

      Assert.Equal("Bob", task.AssignedTo);
    }
  }
}