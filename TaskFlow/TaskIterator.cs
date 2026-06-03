using System.Collections.Generic;
using System.Threading.Tasks;

public class TaskIterator {
  private List<Task> _tasks;
  private int _currentIndex;

  public TaskIterator(List<Task> tasks) {
    _tasks = tasks;
    _currentIndex = 0;
  }
}
public bool HasNext() {
  return _currentIndex < _tasks.Count - 1;
}

public bool HasPrevious() {
  return _currentIndex > 0;
}