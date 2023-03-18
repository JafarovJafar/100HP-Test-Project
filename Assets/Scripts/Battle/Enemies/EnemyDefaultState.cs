using System;

namespace Battle.Enemies
{
    public class EnemyDefaultState : IState
    {
        private EnemyVars _vars;
        
        public EnemyDefaultState(EnemyVars vars)
        {
            _vars = vars;
        }
        
        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void FixedTick()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }
    }
}