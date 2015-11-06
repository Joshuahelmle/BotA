using System;
using BladeOfTheAssassin.Core.Utilities;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Conditions
{
    /// <summary>
    /// determines if the SpellCooldown is Lower than given MaxTimeLeft.
    /// </summary>
    class CoolDownLeftMaxCondition : ICondition
    {
        /// <summary>
        /// The Spell id used to determine the time left to satisfy the condition.
        /// </summary>
        WoWSpell Spell { get; set; }

        /// <summary>
        /// The maximum amount of time left to satisfy the condition.
        /// </summary>
        public TimeSpan MaxTimeLeft { get; set; }

        public CoolDownLeftMaxCondition(WoWSpell spell, TimeSpan maxTimeLeft)
        {
            this.Spell = spell;
            this.MaxTimeLeft = maxTimeLeft;
        }
        public bool Satisfied()
        {
            if (Main.Debug)Log.Diagnostics("CooldownTimeleft of: "+Spell+ " is :"+Spell.CooldownTimeLeft);
            return Spell.CooldownTimeLeft <= MaxTimeLeft;
        }
    }
}
