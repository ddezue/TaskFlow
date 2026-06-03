using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TaskFlow {
  public class TaskIterator {
    private readonly List<Task> _tasks;
    private int _currentIndex;
    private readonly int invalidIndex;
    private readonly int FirstIndex;
    private readonly int NextTaskOffset;
    private readonly int EmptyListCount;

    public TaskIterator(List<Task> tasks) {
      invalidIndex = -1;
      FirstIndex = 0;
      NextTaskOffset = 1;
      EmptyListCount = 0;

      if (tasks == null) {
        _tasks = new List<Task>();
      } else {
        _tasks = tasks;
      }

      if (_tasks.Count > EmptyListCount) {
        _currentIndex = FirstIndex;
      } else {
        _currentIndex = invalidIndex;
      }
    }

    public bool HasNext() {
      int lastIndex;
      lastIndex = NextTaskOffset;
      return _currentIndex < _tasks.Count - lastIndex;
    }

    public bool HasPrevious() {
      return _currentIndex > FirstIndex;
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
      if (_tasks.Count == EmptyListCount || _currentIndex < FirstIndex || _currentIndex >= _tasks.Count) {
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