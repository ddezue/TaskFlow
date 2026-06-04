using TaskFlow.Model;

namespace TaskFlow.Tests.Model {
  public class TaskStateTests {
    [Fact]
    public void NewState_Next_ShouldBecomeInProgress() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High");
      _ = Assert.IsType<NewState>(task.State);
      task.State.Next(task);
      _ = Assert.IsType<InProgressState>(task.State);
    }

    [Fact]
    public void InProgressState_Next_ShouldBecomeReview() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new InProgressState()
      };

      task.State.Next(task);
      _ = Assert.IsType<ReviewState>(task.State);
    }

    [Fact]
    public void InProgressState_Previous_ShouldBecomeNew() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new InProgressState()
      };

      task.State.Previous(task);
      _ = Assert.IsType<NewState>(task.State);
    }

    [Fact]
    public void ReviewState_Next_ShouldBecomeDone() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new ReviewState()
      };

      task.State.Next(task);
      _ = Assert.IsType<DoneState>(task.State);
    }

    [Fact]
    public void ReviewState_Previous_ShouldBecomeInProgress() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new ReviewState()
      };

      task.State.Previous(task);
      _ = Assert.IsType<InProgressState>(task.State);
    }

    [Fact]
    public void DoneState_Previous_ShouldBecomeReview() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new DoneState()
      };

      task.State.Previous(task);
      _ = Assert.IsType<ReviewState>(task.State);
    }

    [Fact]
    public void DoneState_Next_ShouldDoNothing() {
      TaskFlow.Model.Task task = new TaskFlow.Model.Task("Test", "Desc", "2025-12-31", "High") {
        State = new DoneState()
      };

      task.State.Next(task);
      _ = Assert.IsType<DoneState>(task.State);
    }
  }
}