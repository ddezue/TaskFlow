using System.Collections.Generic;

namespace TaskFlow.Model {
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

      _tasks = tasks ?? new List<Task>();

      _currentIndex = _tasks.Count > _emptyListCount ? _firstIndex : _invalidIndex;
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
      return _tasks.Count == _emptyListCount || _currentIndex < _firstIndex || _currentIndex >= _tasks.Count ? null : _tasks[_currentIndex];
    }

    public void AssignCurrentTo(string userName) {
      Task current = GetCurrent();
      if (current != null) {
        current.AssignedTo = userName;
      }
    }
  }
}