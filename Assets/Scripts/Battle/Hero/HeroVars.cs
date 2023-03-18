using System.Collections.Generic;
using UnityEngine;

namespace Battle.Hero
{
    [System.Serializable]
    public class HeroVars
    {
        public GameObject GameObject;
        public Transform Transform;
        public Weapon Weapon;
        public AttackTrigger AttackTrigger;
        public List<Enemy> EnemiesInRange = new List<Enemy>();
    }
}