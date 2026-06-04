using Xunit;
using TaskFlow;

namespace TaskFlow.Tests.Model {
  public class TaskStateTests {
    [Fact]
    public void NewState_Next_ShouldBecomeInProgress() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High");
      Assert.IsType<NewState>(task.State);
      task.State.Next(task);
      Assert.IsType<InProgressState>(task.State);
    }

    [Fact]
    public void InProgressState_Next_ShouldBecomeReview() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new InProgressState()
      };

      task.State.Next(task);
      Assert.IsType<ReviewState>(task.State);
    }

    [Fact]
    public void InProgressState_Previous_ShouldBecomeNew() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new InProgressState()
      };

      task.State.Previous(task);
      Assert.IsType<NewState>(task.State);
    }

    [Fact]
    public void ReviewState_Next_ShouldBecomeDone() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new ReviewState()
      };

      task.State.Next(task);
      Assert.IsType<DoneState>(task.State);
    }

    [Fact]
    public void ReviewState_Previous_ShouldBecomeInProgress() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new ReviewState()
      };

      task.State.Previous(task);
      Assert.IsType<InProgressState>(task.State);
    }

    [Fact]
    public void DoneState_Previous_ShouldBecomeReview() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new DoneState()
      };

      task.State.Previous(task);
      Assert.IsType<ReviewState>(task.State);
    }

    [Fact]
    public void DoneState_Next_ShouldDoNothing() {
      Task task = new Task("Test", "Desc", "2025-12-31", "High") {
        State = new DoneState()
      };

      task.State.Next(task);
      Assert.IsType<DoneState>(task.State);
    }
  }
}