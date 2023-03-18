using System;
using UnityEngine;
using Battle.Hero;

namespace Battle
{
    public class HeroBase : MonoBehaviour, IHero
    {
        public event Action Destroyed;

        [SerializeField]private HeroVars _vars;

        private StateMachine _stateMachine;

        private GameObject _gameObject;
        private Transform _transform;

        public void Init()
        {
            _gameObject = gameObject;
            _transform = transform;

            _vars.AttackTrigger.Init();
            _vars.AttackTrigger.Entered += AttackTrigger_Entered;
        }

        private void AttackTrigger_Entered(Enemy enemy)
        {
            _vars.EnemiesInRange.Add(enemy);
        }

        private void ChangeDefaultState() => _stateMachine.ChangeState(new HeroBaseDefaultState(_vars));
        
        private void Update() => _stateMachine.Tick();
        private void FixedUpdate() => _stateMachine.FixedTick();

        private void Awake()
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}