namespace TaskFlow.Model {
  public class TaskTemplate {
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string Priority { get; set; }

    public TaskTemplate(string title, string description, string dueDate, string priority) {
      Title = title;
      Description = description;
      DueDate = dueDate;
      Priority = priority;
    }

    public Task CreateTask() {
      return new Task(Title, Description, DueDate, Priority);
    }
  }
}