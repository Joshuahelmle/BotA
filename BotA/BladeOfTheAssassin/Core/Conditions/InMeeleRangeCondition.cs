using Styx;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions
{
    class InMeeleRangeCondition : ICondition
    {

        private WoWUnit _target;

        public InMeeleRangeCondition(WoWUnit target)
        {
            _target = target;
        }

        public InMeeleRangeCondition()
        {
            _target = StyxWoW.Me.CurrentTarget;
        }

        public bool Satisfied()
        {
            return _target != null && StyxWoW.Me.IsWithinMeleeRangeOf(_target);
        }
    }
}
