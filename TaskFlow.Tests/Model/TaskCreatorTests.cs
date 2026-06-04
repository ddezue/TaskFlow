using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskCreatorTests {
    [Fact]
    public void AddTemplate_ShouldStoreTemplate() {
      TaskCreator creator = new TaskCreator();
      TaskTemplate template = new TaskTemplate("Template", "Desc", "2025-12-31", "High");

      creator.AddTemplate(template);
      TaskFlow.Model.Task task = creator.CreateFromTemplate(0);

      Assert.NotNull(task);
      Assert.Equal("Template", task.Title);
    }

    [Fact]
    public void CreateFromTemplate_InvalidIndex_ShouldReturnNull() {
      TaskCreator creator = new TaskCreator();
      TaskFlow.Model.Task result = creator.CreateFromTemplate(99);

      Assert.Null(result);
    }

    [Fact]
    public void CloneTask_ShouldReturnClonedTask() {
      TaskFlow.Model.Task original = new TaskFlow.Model.Task("Original", "Desc", "2025-12-31", "High");
      TaskCreator creator = new TaskCreator();
      TaskFlow.Model.Task cloned = creator.CloneTask(original);

      Assert.NotEqual(original.Id, cloned.Id);
      Assert.Equal(original.Title, cloned.Title);
    }
  }
}