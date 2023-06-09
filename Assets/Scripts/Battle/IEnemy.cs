﻿using UnityEngine;

namespace Battle
{
    public interface IEnemy : IDestroyable, IDamageable, IPoolable
    {
        Vector3 Position { get; }
        float Cost { get; }

        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
        void SetTarget(IHero hero);
    }
}