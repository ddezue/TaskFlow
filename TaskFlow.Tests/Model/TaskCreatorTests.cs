using Xunit;
using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskCreatorTests {
    [Fact]
    public void AddTemplate_ShouldStoreTemplate() {
      var creator = new TaskCreator();
      var template = new TaskTemplate("Template", "Desc", "2025-12-31", "High");

      creator.AddTemplate(template);
      var task = creator.CreateFromTemplate(0);

      Assert.NotNull(task);
      Assert.Equal("Template", task.Title);
    }

    [Fact]
    public void CreateFromTemplate_InvalidIndex_ShouldReturnNull() {
      var creator = new TaskCreator();
      var result = creator.CreateFromTemplate(99);
      Assert.Null(result);
    }

    [Fact]
    public void CloneTask_ShouldReturnClonedTask() {
      Task original = new Task("Original", "Desc", "2025-12-31", "High");
      var creator = new TaskCreator();

      var cloned = creator.CloneTask(original);
      Assert.NotEqual(original.Id, cloned.Id);
      Assert.Equal(original.Title, cloned.Title);
    }
  }
}
