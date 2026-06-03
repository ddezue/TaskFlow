namespace TaskFlow.Model {
  public class InProgressState : TaskState {
    public override string GetStatus() {
      return "В работе";
    }

    public override void Next(Task task) {
      task.State = new ReviewState();
    }

    public override void Previous(Task task) {
      task.State = new NewState();
    }

    public override TaskState Clone() {
      return new InProgressState();
    }
  }
}