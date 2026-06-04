using Xunit;
using TaskFlow;

namespace TaskFlow.Tests.Model {
  public class TaskCreatorTests {
    [Fact]
    public void AddTemplate_ShouldStoreTemplate() {
      TaskCreator creator = new TaskCreator();
      TaskTemplate template = new TaskTemplate("Template", "Desc", "2025-12-31", "High");

      creator.AddTemplate(template);
      Task task = creator.CreateFromTemplate(0);

      Assert.NotNull(task);
      Assert.Equal("Template", task.Title);
    }

    [Fact]
    public void CreateFromTemplate_InvalidIndex_ShouldReturnNull() {
      TaskCreator creator = new TaskCreator();
      Task result = creator.CreateFromTemplate(99);

      Assert.Null(result);
    }

    [Fact]
    public void CloneTask_ShouldReturnClonedTask() {
      Task original = new Task("Original", "Desc", "2025-12-31", "High");
      TaskCreator creator = new TaskCreator();
      Task cloned = creator.CloneTask(original);

      Assert.NotEqual(original.Id, cloned.Id);
      Assert.Equal(original.Title, cloned.Title);
    }
  }
}