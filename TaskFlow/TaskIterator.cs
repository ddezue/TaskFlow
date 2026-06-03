using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TaskFlow {
  public class TaskIterator {
    private readonly List<Task> _tasks;
    private int _currentIndex;

    public TaskIterator(List<Task> tasks) {
      int noselectedtask;

      noselectedtask = -1;
      if (tasks == null) {
        _tasks = new List<Task>();
      } else {
        _tasks = tasks;
      }

      if (_tasks.Count > 0) {
        _currentIndex = 0;
      } else {
        _currentIndex = noselectedtask;
      }
    }

    public bool HasNext() {
      int lastIndex;

      lastIndex = 1;
      return _currentIndex < _tasks.Count - lastIndex;
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
      if (_tasks.Count == 0 || _currentIndex < 0 || _currentIndex >= _tasks.Count) {
        return null;
      }

      return _tasks[_currentIndex];
    }

    public void AssignCurrentTo(string userName) {
      Task current;

      current = GetCurrent();
      if (current != null) {
        current.AssignedTo = userName;
      }
    }
  }
}