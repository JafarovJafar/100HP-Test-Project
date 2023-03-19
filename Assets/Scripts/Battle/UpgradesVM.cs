using Battle.UI;

namespace Battle
{
    public class UpgradesVM
    {
        public UpgradesVM(IHero hero, UpgradesView view)
        {
            view.UpgradeRangeClicked += hero.UpgradeRange;
            view.UpgradeFrequencyClicked += hero.UpgradeFrequency;
            view.UpgradeStrengthClicked += hero.UpgradeStrength;
        }
    }
}