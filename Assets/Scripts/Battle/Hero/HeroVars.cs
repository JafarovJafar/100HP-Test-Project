using System.Collections.Generic;
using UnityEngine;

namespace Battle.Hero
{
    [System.Serializable]
    public class HeroVars
    {
        [HideInInspector] public GameObject GameObject;
        [HideInInspector] public Transform Transform;
        public GameObject RootGameObject;
        public Collider2D Collider;
        public Weapon Weapon;
        public AttackTrigger AttackTrigger;
        public List<Enemy> EnemiesInRange = new List<Enemy>();
        public ParticleSystem DeathParticle;
        public float Health = 5f;
    }
}