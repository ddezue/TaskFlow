namespace TaskFlow {
  public class ReviewState : TaskState {
    public override string GetStatus() {
      return "На проверке";
    }

    public override void Next(Task task) {
      task.State = new DoneState();
    }

    public override void Previous(Task task) {
      task.State = new InProgressState();
    }

    public override TaskState Clone() {
      return new ReviewState();
    }
  }
}