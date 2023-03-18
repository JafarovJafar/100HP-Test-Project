using System;
using UnityEngine;

namespace Battle.Hero
{
    public class HeroBaseDeathState : IState
    {
        private HeroVars _vars;

        public HeroBaseDeathState(HeroVars vars)
        {
            _vars = vars;
        }
        
        public void Enter()
        {
            _vars.RootGameObject.SetActive(false);
            _vars.DeathParticle.Play();
            _vars.Collider.enabled = false;
        }

        public void Tick()
        {
        }

        public void FixedTick()
        {
        }

        public void Exit()
        {
        }
    }
}