using UnityEngine;

namespace Battle.Hero
{
    public class HeroBaseDefaultState : IState
    {
        private HeroVars _vars;

        public HeroBaseDefaultState(HeroVars vars)
        {
            _vars = vars;
        }

        public void Enter()
        {
            _vars.AttackTrigger.Activate();
            _vars.Weapon.Activate();
        }

        public void Tick()
        {
            if (_vars.Weapon.IsReloading) return;

            float minDistance = float.MaxValue;
            float currentDistance;
            IEnemy targetEnemy = null;
            IEnemy currentEnemy;

            for (int i = 0; i < _vars.EnemiesInRange.Count; i++)
            {
                currentEnemy = _vars.EnemiesInRange[i];

                if (currentEnemy.IsDestroyed)
                {
                    _vars.EnemiesInRange.RemoveAt(i);
                    i--;
                    continue;
                }

                currentDistance = SqrDistance(currentEnemy.Position, _vars.Transform.position);

                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    targetEnemy = _vars.EnemiesInRange[i];
                }
            }

            if (targetEnemy != null)
            {
                _vars.Weapon.ShootAt(targetEnemy);
            }
        }

        public void FixedTick()
        {
        }

        public void Exit()
        {
        }

        private float SqrDistance(Vector2 first, Vector2 second)
        {
            Vector2 vector = second - first;
            return vector.x * vector.x + vector.y * vector.y;
        }
    }
}