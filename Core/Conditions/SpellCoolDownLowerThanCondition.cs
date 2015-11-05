using System;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Conditions
{
    class SpellCoolDownLowerThanCondition : ICondition
    {
        private TimeSpan _maxCooldown;
        private WoWSpell _spell;

        /// <summary>
        /// checks if a given Spell's cooldown is lower than the given TimeSpan
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="maxCooldown"></param>
        public SpellCoolDownLowerThanCondition(WoWSpell spell, TimeSpan maxCooldown)
        {
            this._spell = spell;
            this._maxCooldown = maxCooldown;
        }
        public bool Satisfied()
        {
            return !CastManager.SpellIsOnCooldown(_spell.Id) || _spell.CooldownTimeLeft < _maxCooldown;
        }
    }
}
