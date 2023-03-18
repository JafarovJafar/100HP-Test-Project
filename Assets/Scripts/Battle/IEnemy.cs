using UnityEngine;

namespace Battle
{
    public interface IEnemy : IDestroyable, IDamageable
    {
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}