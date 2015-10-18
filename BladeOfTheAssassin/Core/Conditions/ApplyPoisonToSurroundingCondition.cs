using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Collections.Generic;
namespace BladeOfTheAssassin.Core.Conditions
{
    /// <summary>
    /// Condition based on a static boolean value, such as a setting.
    /// </summary>
    public class ApplyPoisonToSurroundingCondition : ICondition
    {
        /// <summary>
        /// The value to determine if the condition has been satisfied.
        /// </summary>
        private WoWUnit _bleedingTarget { get; set; }

        public ApplyPoisonToSurroundingCondition(WoWUnit bleedingTarget)
        {
            this._bleedingTarget = bleedingTarget;
        }

        public bool Satisfied()
        {

            return (_bleedingTarget != null) ? _bleedingTarget.AuraRemainingTime(SpellBook.CastRupture).TotalSeconds <= 2 : false;
        }
    }

}