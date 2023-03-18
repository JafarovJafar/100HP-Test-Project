using UnityEngine;

namespace Battle
{
    public interface IEnemy : IDestroyable, IDamageable
    {
        Vector3 Position { get; }
        
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
        void SetTarget(IHero hero);
    }
}