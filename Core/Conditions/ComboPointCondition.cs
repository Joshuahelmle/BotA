using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class ComboPointCondition : ICondition
    {

        private int _needComboPointsAmount;

        public ComboPointCondition(int needComboPointsAmount)
        {
            _needComboPointsAmount = needComboPointsAmount;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.ComboPoints >= _needComboPointsAmount;
        }
    }
}