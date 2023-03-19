using System;
using UnityEngine;

namespace Battle.Enemies
{
    public class EnemyDieState : IState
    {
        private EnemyVars _vars;

        private Action _finished;

        public EnemyDieState(EnemyVars vars, Action finished)
        {
            _vars = vars;
            _finished = finished;
        }

        public void Enter()
        {
            _vars.Rigidbody.velocity = Vector2.zero;
            _vars.Rigidbody.isKinematic = true;
            _vars.Collider.enabled = false;
            _vars.DieParticle.Play();

            _vars.RootTransform.gameObject.SetActive(false);
        }

        public void Tick()
        {
        }

        public void FixedTick()
        {
            if (_vars.DieParticle.isPlaying) return;

            _finished?.Invoke();
        }

        public void Exit()
        {
        }
    }
}