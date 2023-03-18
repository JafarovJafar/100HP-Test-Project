using UnityEngine;

public interface IPoolable
{
    bool IsActive { get; }
    
    void Activate();
    void DeActivate();
    void SetParent(Transform parent);
}