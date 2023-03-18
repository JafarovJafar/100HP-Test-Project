using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class SpawnPointsHelper
    {
        [SerializeField] private float _radius = 20f;

        // сделал отдельный класс, чтобы можно было в будущем подсоединить другую логику. Например сделать заранее заданные точки спавна

        public (Vector3, Quaternion) GetRandomPoint()
        {
            float randomAngle = Random.Range(0, 360);
            Vector2 direction = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;

            Vector2 position = direction * _radius;

            return (position, Quaternion.identity);
        }
    }
}