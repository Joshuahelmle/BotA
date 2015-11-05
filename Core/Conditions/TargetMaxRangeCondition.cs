using Styx;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class TargetMaxRangeCondition : ICondition
    {

        private WoWUnit _target;
        private int _range;

        public TargetMaxRangeCondition(WoWUnit target, int range)
        {
            _target = target;
            _range = range;
        }

        public bool Satisfied()
        {
            return  _target != null && _target.Distance <= _range;
        }
    }
}