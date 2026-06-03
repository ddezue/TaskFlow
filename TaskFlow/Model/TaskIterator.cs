using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TaskFlow {
  public class TaskIterator {
    private readonly List<Task> _tasks;
    private int _currentIndex;
    private readonly int _invalidIndex;
    private readonly int _firstIndex;
    private readonly int _nextTaskOffset;
    private readonly int _emptyListCount;

    public TaskIterator(List<Task> tasks) {
      _invalidIndex = -1;
      _firstIndex = 0;
      _nextTaskOffset = 1;
      _emptyListCount = 0;

      if (tasks == null) {
        _tasks = new List<Task>();
      } else {
        _tasks = tasks;
      }

      if (_tasks.Count > _emptyListCount) {
        _currentIndex = _firstIndex;
      } else {
        _currentIndex = _invalidIndex;
      }
    }

    public bool HasNext() {
      return _currentIndex < _tasks.Count - _nextTaskOffset;
    }

    public bool HasPrevious() {
      return _currentIndex > _firstIndex;
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
      if (_tasks.Count == _emptyListCount || _currentIndex < _firstIndex || _currentIndex >= _tasks.Count) {
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