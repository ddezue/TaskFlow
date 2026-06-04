using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskTests {
    [Fact]
    public void Constructor_ShouldInitializeProperties() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Description", "2025-12-31", "High");
      Assert.NotNull(task.Id);
      Assert.Equal("Test", task.Title);
      Assert.Equal("Description", task.Description);
      Assert.Equal("2025-12-31", task.DueDate);
      Assert.Equal("High", task.Priority);
      _ = Assert.IsType<NewState>(task.State);
      Assert.Equal(string.Empty, task.AssignedTo);
    }

    [Fact]
    public void Clone_ShouldCreateDeepCopy() {
      TaskFlow.Model.Task original = new TaskFlow.Model.Task("Original", "Desc", "2025-12-31", "Low") {
        AssignedTo = "John",
        State = new InProgressState()
      };

      TaskFlow.Model.Task cloned = original.Clone();
      Assert.NotEqual(original.Id, cloned.Id);
      Assert.Equal(original.Title, cloned.Title);
      Assert.Equal(original.Description, cloned.Description);
      Assert.Equal(original.DueDate, cloned.DueDate);
      Assert.Equal(original.Priority, cloned.Priority);
      Assert.Equal(original.AssignedTo, cloned.AssignedTo);
      _ = Assert.IsType<InProgressState>(cloned.State);
    }
  }
}