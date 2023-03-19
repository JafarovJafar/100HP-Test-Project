namespace Battle
{
    public interface IBattleModel
    {
        IHero Hero { get; }
        IBalance Balance { get; }
    }
}