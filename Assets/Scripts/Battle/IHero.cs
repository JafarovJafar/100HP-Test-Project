using System;
using UnityEngine;

public interface IHero : IDamageable, IDestroyable
{
    Vector3 Position { get; }
}