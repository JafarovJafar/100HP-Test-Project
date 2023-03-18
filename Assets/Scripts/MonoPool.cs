using System.Collections.Generic;
using UnityEngine;

public class MonoPool : MonoBehaviour
{
    public static MonoPool Instance => _instance;
    private static MonoPool _instance;

    private Dictionary<IPoolable, List<IPoolable>> _pool = new Dictionary<IPoolable, List<IPoolable>>();

    private Transform _transform;

    public T Get<T>(T prefab) where T : MonoBehaviour, IPoolable
    {
        T item;

        if (!_pool.ContainsKey(prefab))
        {
            _pool.Add(prefab, new List<IPoolable>());
        }

        item = _pool[prefab].Find(x => !x.IsActive) as T;

        if (item == null)
        {
            item = Instantiate(prefab);
            _pool[prefab].Add(item);
        }

        item.Activate();

        return item;
    }

    public void ReturnAllItems()
    {
        foreach (var poolValue in _pool.Values)
        {
            foreach (var poolable in poolValue)
            {
                poolable.SetParent(_transform);
                poolable.DeActivate();
            }
        }
    }
    
    private void Awake()
    {
        _transform = transform;
        _instance = this;
    }
}