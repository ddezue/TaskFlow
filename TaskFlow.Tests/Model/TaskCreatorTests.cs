using Xunit;
using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskCreatorTests {
    [Fact]
    public void AddTemplate_ShouldStoreTemplate() {
      TaskCreator creator;
      TaskTemplate template;
      Task task;

      creator = new TaskCreator();
      template = new TaskTemplate("Template", "Desc", "2025-12-31", "High");

      creator.AddTemplate(template);
      task = creator.CreateFromTemplate(0);

      Assert.NotNull(task);
      Assert.Equal("Template", task.Title);
    }

    [Fact]
    public void CreateFromTemplate_InvalidIndex_ShouldReturnNull() {
      TaskCreator creator;
      Task result;

      creator = new TaskCreator();
      result = creator.CreateFromTemplate(99);

      Assert.Null(result);
    }

    [Fact]
    public void CloneTask_ShouldReturnClonedTask() {
      Task original;
      TaskCreator creator;
      Task cloned;

      original = new Task("Original", "Desc", "2025-12-31", "High");
      creator = new TaskCreator();
      cloned = creator.CloneTask(original);

      Assert.NotEqual(original.Id, cloned.Id);
      Assert.Equal(original.Title, cloned.Title);
    }
  }
}