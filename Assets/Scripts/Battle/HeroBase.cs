using System;
using UnityEngine;
using Battle.Hero;

namespace Battle
{
    public class HeroBase : MonoBehaviour, IHero
    {
        public event Action Destroyed;

        public Vector3 Position => _vars.Transform.position;
        
        [SerializeField] private HeroVars _vars;

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