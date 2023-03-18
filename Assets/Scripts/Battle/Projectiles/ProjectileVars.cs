using System;
using UnityEngine;

namespace Battle.Projectiles
{
    [Serializable]
    public class ProjectileVars
    {
        [HideInInspector] public Transform Transform;
        public GameObject RootGameObject;
        public Rigidbody2D Rigidbody;
        public Collider2D Collider;
        public Trail Trail;
        public float MoveSpeed;
        public ParticleSystem DestroyParticle;
        public float LifeTime = 10f;
    }
}