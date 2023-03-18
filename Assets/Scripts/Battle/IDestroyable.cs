using System;

public interface IDestroyable
{
    event Action<IDestroyable> Destroyed;
    
    bool IsDestroyed { get; }

    void Destroy();
}