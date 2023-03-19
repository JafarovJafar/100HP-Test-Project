using System;
using UnityEngine;

namespace Battle
{
    public interface IHero : IDamageable, IDestroyable
    {
        event Action Upgraded;
        
        Vector3 Position { get; }
        Stats AttackRangeStats { get; }
        Stats AttackIntervalStats { get; }
        Stats AttackStrengthStats { get; }

        int CurrentAttackRangeLevel { get; }
        int CurrentAttackIntervalLevel { get; }
        int CurrentAttackStrengthLevel { get; }

        void UpgradeRange();
        void UpgradeFrequency();
        void UpgradeStrength();
    }
}