using System;
using UnityEngine;

namespace Battle.Enemies
{
    [Serializable]
    public class EnemyVars
    {
        [HideInInspector] public Transform Transform;
        public Transform RootTransform;
        public Rigidbody2D Rigidbody;
        public Collider2D Collider;
        public float MoveSpeed = 2f;
        public float RotateLerp = 5f;
        public float Strength = 1f;
        public float AttackInterval = 2f;
        public float Health = 1;
        public IHero Hero;
        public ParticleSystem DieParticle;
        public bool CanAttackHero;
    }
}