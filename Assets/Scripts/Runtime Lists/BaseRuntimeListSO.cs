using System.Collections.Generic;
using UnityEngine;

public class BaseRuntimeListSO<T> : ScriptableObject
{
    public event System.Action OnLastObjectRemoved = delegate { };

    private readonly List<T> _list = new List<T>();

    public int Count => _list.Count;

    public void Add(T listObject)
    {
        _list.Add(listObject);
    }

    public void Remove(T listObject)
    {
        if (_list.Remove(listObject))
        {
            if (_list.Count == 0)
            {
                OnLastObjectRemoved.Invoke();
            }
        }
    }

    public void Remove(int index)
    {
        if (index.InRange(0, _list.Count - 1))
        {
            Remove(_list[index]);
        }
    }

    public T Get(int index)
    {
        return _list[index];
    }

    public T[] GetAll()
    {
        return _list.ToArray();
    }

    public T Find(System.Predicate<T> match)
    {
        return _list.Find(match);
    }

    public List<T> FindAll(System.Predicate<T> match)
    {
        return _list.FindAll(match);
    }

    public void Clear()
    {
        _list.Clear();
    }
}
