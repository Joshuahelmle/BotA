﻿using System.Threading.Tasks;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities
{
    /// <summary>
    /// Ability interface that all abilities adhere to.
    /// </summary>
    public interface IAbility
    {
        /// <summary>
        /// The category of the ability. Displayed during logging.
        /// </summary>
        AbilityCategory Category { get; set; }
        DrCategory DrCategory { get; set; }


        WoWUnit Target { get; set; }

        // <summary>
        /// The spell that the ability directly relates to.
        /// </summary>
        WoWSpell Spell { get; set; }


        /// <summary>
        /// Casts the ability's spell on the specified target. The cast will only be attempted if the conditions list is completely satisfied first.
        /// </summary>
        /// <returns>Returns true on a successful cast.</returns>
        Task<bool> CastOnTarget(WoWUnit target);

        /// <summary>
        /// Provides an opportunity to allow the ability to update based on dynamic information. This should be called during Main.Pulse().
        /// </summary>
        void Update();



        
    }
}