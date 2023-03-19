using System;
using UnityEngine;

namespace Battle.Projectiles
{
    public class ProjectileDieState : IState
    {
        private ProjectileVars _vars;

        private Action _finished;
        
        public ProjectileDieState(ProjectileVars vars, Action finished)
        {
            _vars = vars;
            _finished = finished;
        }

        public void Enter()
        {
            _vars.RootGameObject.SetActive(false);
            _vars.Rigidbody.velocity = Vector2.zero;
            _vars.Rigidbody.isKinematic = true;
            _vars.Collider.enabled = false;
            _vars.DestroyParticle.Play();
            _vars.Trail.DeActivate();
        }

        public void Tick()
        {
            if (_vars.DestroyParticle.isPlaying) return;
            
            _finished?.Invoke();
        }

        public void FixedTick()
        {
        }

        public void Exit()
        {
        }
    }
}