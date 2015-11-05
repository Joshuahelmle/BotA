using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class TargetNotInCombatCondition : ICondition
    {
        private WoWUnit _target;

        public TargetNotInCombatCondition(WoWUnit target)
        {
            _target = target;
        }

        public bool Satisfied()
        {
            return !(_target == null || _target.Combat);
        }
    }
}