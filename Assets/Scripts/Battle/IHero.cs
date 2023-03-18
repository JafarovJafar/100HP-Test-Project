using System;
using UnityEngine;

public interface IHero
{
    event Action Destroyed;

    Vector3 Position { get; }
}