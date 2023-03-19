using System;
using UnityEngine;
using Battle.Hero;

namespace Battle
{
    public class HeroBase : MonoBehaviour, IHero
    {
        public event Action Upgraded;
        public event Action<IDestroyable> Destroyed;
        public event Action<float> TakenDamage;

        public Vector3 Position => _vars.Transform.position;
        public Stats AttackRangeStats => _vars.AttackTrigger.Stats;
        public Stats AttackIntervalStats => _vars.Weapon.IntervalStats;
        public Stats AttackStrengthStats => _vars.Weapon.StrengthStats;

        public int CurrentAttackRangeLevel => _vars.AttackTrigger.CurrentLevel;
        public int CurrentAttackIntervalLevel => _vars.Weapon.CurrentIntervalLevel;
        public int CurrentAttackStrengthLevel => _vars.Weapon.CurrentStrengthLevel;

        public bool IsDestroyed => _isDestroyed;

        [SerializeField] private HeroVars _vars;

        private bool _isDestroyed;

        private StateMachine _stateMachine = new StateMachine();

        public void Init()
        {
            _vars.GameObject = gameObject;
            _vars.Transform = transform;

            _vars.Weapon.Init();

            _vars.AttackTrigger.Init();
            _vars.AttackTrigger.Entered += AttackTrigger_Entered;

            ChangeDefaultState();
        }

        public void TakeDamage(float damage)
        {
            _vars.Health -= damage;

            if (_vars.Health <= 0f)
            {
                Destroy();
            }
            else
            {
                TakenDamage?.Invoke(damage);
            }
        }

        public void Destroy()
        {
            _isDestroyed = true;
            _stateMachine.ChangeState(new HeroBaseDeathState(_vars));
            Destroyed?.Invoke(this);
        }

        public void UpgradeRange()
        {
            _vars.AttackTrigger.Upgrade();
            Upgraded?.Invoke();
        }

        public void UpgradeFrequency()
        {
            _vars.Weapon.UpgradeFrequency();
            Upgraded?.Invoke();
        }

        public void UpgradeStrength()
        {
            _vars.Weapon.UpgradeStrength();
            Upgraded?.Invoke();
        }

        private void AttackTrigger_Entered(Enemy enemy)
        {
            _vars.EnemiesInRange.Add(enemy);
        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new HeroBaseDefaultState(_vars));

        private void Update() => _stateMachine.Tick();
    }
}