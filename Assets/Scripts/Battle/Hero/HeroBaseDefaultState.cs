namespace Battle.Hero
{
    public class HeroBaseDefaultState : IState
    {
        private HeroVars _vars;

        public HeroBaseDefaultState(HeroVars vars)
        {
            _vars = vars;
        }

        public void Enter(){}
        public void Tick(){}
        public void FixedTick(){}
        public void Exit(){}
    }
}