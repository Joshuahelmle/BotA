using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class TargetMinRangeCondition : ICondition
    {
        private WoWUnit _target;
        private int _range;

        public TargetMinRangeCondition(WoWUnit target, int range)
        {
            _target = target;
            _range = range;
        }

        public bool Satisfied()
        {
            return _target != null && _target.Distance >= _range;
        }
    }
}