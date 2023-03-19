using System;

namespace Battle
{
    public interface IBattleModel
    {
        event Action Finished;
        event Action HeroDied;
        
        IHero Hero { get; }
        IBalance Balance { get; }

        void Finish();
    }
}