using System.Collections.Generic;
using UnityEngine;

namespace Battle.Hero
{
    [System.Serializable]
    public class HeroVars
    {
        [HideInInspector] public GameObject GameObject;
        [HideInInspector] public Transform Transform;
        public Weapon Weapon;
        public AttackTrigger AttackTrigger;
        public List<Enemy> EnemiesInRange = new List<Enemy>();
    }
}