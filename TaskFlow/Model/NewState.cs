namespace TaskFlow {
  public class NewState : TaskState {
    public override string GetStatus() {
      return "Новая";
    }

    public override void Next(Task task) {
      task.State = new InProgressState();
    }

    public override void Previous(Task task) {
    }

    public override TaskState Clone() {
      return new NewState();
    }
  }
}