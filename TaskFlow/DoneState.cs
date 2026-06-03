namespace TaskFlow {
  public class DoneState : TaskState {
    public override string GetStatus() {
      return "Завершена";
    }

    public override void Next(Task task) {
    }

    public override void Previous(Task task) {
      task.State = new ReviewState();
    }

    public override TaskState Clone() {
      return new DoneState();
    }
  }
}