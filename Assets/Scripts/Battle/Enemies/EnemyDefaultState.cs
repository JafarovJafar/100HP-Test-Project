using UnityEngine;

namespace Battle.Enemies
{
    public class EnemyDefaultState : IState
    {
        private EnemyVars _vars;

        private Vector2 _modeDirection;
        private float _lastAttackTime;

        public EnemyDefaultState(EnemyVars vars)
        {
            _vars = vars;
        }

        public void Enter()
        {
            _vars.Rigidbody.isKinematic = false;
            _vars.Collider.enabled = true;
        }

        public void Tick()
        {

        }

        public void FixedTick()
        {
            _modeDirection = _vars.Hero.Position - _vars.Transform.position;
            _modeDirection.Normalize();
            _vars.Rigidbody.velocity = _modeDirection * _vars.MoveSpeed;

            if (_vars.CanAttackHero)
            {
                if (Time.time > _lastAttackTime + _vars.AttackInterval)
                {
                    _lastAttackTime = Time.time;
                    _vars.Hero.TakeDamage(_vars.Strength);
                }
            }
            else
            {
                _lastAttackTime = 0f;
            }
        }

        public void Exit()
        {

        }
    }
}