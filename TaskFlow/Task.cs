using System;

namespace TaskFlow {
  public class Task {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string AssignedTo { get; set; }


    public Task(string title, string description, string dueDate, string priority) {
      Id = Guid.NewGuid().ToString();
      Title = title;
      Description = description;
      DueDate = dueDate;
      Priority = priority;
      Status = "Новая";
      AssignedTo = string.Empty;
    }

    public Task Clone() {
      return new Task(Title, Description, DueDate, Priority) {
        AssignedTo = this.AssignedTo,
        Status = this.Status
      };
    }
  }
}
