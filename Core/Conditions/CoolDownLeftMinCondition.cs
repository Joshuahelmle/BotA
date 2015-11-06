using System;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Conditions
{
    class CoolDownLeftMinCondition : ICondition
    {
        private WoWSpell _spell;
        private TimeSpan _minCooldown;

        public CoolDownLeftMinCondition(WoWSpell spell, TimeSpan minCooldown)
        {
            _spell = spell;
            _minCooldown = minCooldown;
        }

        public bool Satisfied()
        {
            return _spell.CooldownTimeLeft >= _minCooldown;
        }
    }
}
