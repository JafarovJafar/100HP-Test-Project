using System;

public interface IDestroyable
{
    event Action Destroyed;

    void Destroy();
}