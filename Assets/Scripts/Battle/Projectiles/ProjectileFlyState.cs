namespace Battle.Projectiles
{
    public class ProjectileFlyState : IState
    {
        private ProjectileVars _vars;
        
        public ProjectileFlyState(ProjectileVars vars)
        {
            _vars = vars;
        }
        
        public void Enter()
        {
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