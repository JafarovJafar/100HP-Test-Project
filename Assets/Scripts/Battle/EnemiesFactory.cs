using UnityEngine;
using Battle.Enemies;

namespace Battle
{
    public class EnemiesFactory : MonoBehaviour
    {
        private IHero _hero;
        
        public void Init(IHero hero)
        {
            _hero = hero;
        }

        public Enemy GetRandom()
        {
            //@TODO
            return null;
        }
    }
}