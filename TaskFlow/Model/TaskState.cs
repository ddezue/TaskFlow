namespace TaskFlow.Model {
  public abstract class TaskState {
    public abstract string GetStatus();
    public abstract void Next(Task task);
    public abstract void Previous(Task task);
    public abstract TaskState Clone();
  }
}