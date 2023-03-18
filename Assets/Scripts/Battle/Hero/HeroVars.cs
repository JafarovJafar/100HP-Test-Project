using System.Collections.Generic;

namespace Battle.Hero
{
    [System.Serializable]
    public class HeroVars
    {
        public AttackTrigger AttackTrigger;
        public List<Enemy> EnemiesInRange = new List<Enemy>();
    }
}