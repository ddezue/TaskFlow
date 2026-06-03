using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskFlow {
  public class TaskIterator {
    private readonly List<Task> _tasks;
    private int _currentIndex;

    public TaskIterator(List<Task> tasks) {
      _tasks = tasks;
      _currentIndex = 0;
    }

    public bool HasNext() {
      return _currentIndex < _tasks.Count - 1;
    }

    public bool HasPrevious() {
      return _currentIndex > 0;
    }

    public Task Next() {
      if (HasNext()) {
        ++_currentIndex;
        return _tasks[_currentIndex];
      }
      return null;
    }

    public Task Previous() {
      if (HasPrevious()) {
        --_currentIndex;
        return _tasks[_currentIndex];
      }
      return null;
    }

    public Task GetCurrent() {
      if (_tasks == null || _tasks.Count == 0) {
        return null;
      }
      return _tasks[_currentIndex];
    }

    public void AssignCurrentTo(string userName) {
      Task current = GetCurrent();
      if (current != null) {
        current.AssignedTo = userName;
      }
    }
  }
}