using System;
using UnityEngine;
using Battle.Hero;

namespace Battle
{
    public class HeroBase : MonoBehaviour, IHero
    {
        public event Action<IDestroyable> Destroyed;
        public event Action<float> TakenDamage;

        public Vector3 Position => _vars.Transform.position;
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

        public void UpgradeAttackRadius() => _vars.AttackTrigger.Upgrade();
        public void UpgradeAttackFrequency() => _vars.Weapon.UpgradeFrequency();
        public void UpgradeAttackStrength() => _vars.Weapon.UpgradeStrength();

        private void AttackTrigger_Entered(Enemy enemy)
        {
            _vars.EnemiesInRange.Add(enemy);
        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new HeroBaseDefaultState(_vars));

        private void Update() => _stateMachine.Tick();
    }
}