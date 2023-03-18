using System;

public interface IDestroyable
{
    event Action Destroyed;
    
    bool IsDestroyed { get; }

    void Destroy();
}