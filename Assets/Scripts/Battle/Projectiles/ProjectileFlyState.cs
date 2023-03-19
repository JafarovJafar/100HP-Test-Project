using System;
using UnityEngine;

namespace Battle.Projectiles
{
    public class ProjectileFlyState : IState
    {
        private Action _lifeTimeSpent;

        private ProjectileVars _vars;

        private float _startTime;

        public ProjectileFlyState(ProjectileVars vars, Action lifeTimeSpent)
        {
            _vars = vars;
            _lifeTimeSpent = lifeTimeSpent;
        }
        
        public void Enter()
        {
            _vars.Rigidbody.isKinematic = false;
            _vars.Collider.enabled = true;
            _vars.Trail.Activate();

            _startTime = Time.time;
        }

        public void Tick()
        {
        }

        public void FixedTick()
        {
            if (Time.time > _startTime + _vars.LifeTime)
            {
                _lifeTimeSpent?.Invoke();
                return;
            }

            _vars.Rigidbody.velocity = _vars.Transform.up * _vars.MoveSpeed;
        }

        public void Exit()
        {
        }
    }
}