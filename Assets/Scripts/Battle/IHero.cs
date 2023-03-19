using UnityEngine;

namespace Battle
{
    public interface IHero : IDamageable, IDestroyable
    {
        Vector3 Position { get; }

        void UpgradeRange();
        void UpgradeFrequency();
        void UpgradeStrength();
    }
}