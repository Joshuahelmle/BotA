using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media;
using BladeOfTheAssassin.Core.Abilities;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Utilities;
using Buddy.Coroutines;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Managers
{
    /// <summary>
    ///     Provides the management of spell casting.
    /// </summary>
    public static class CastManager
    {
        /// <summary>
        ///     Determine if the spell is on cooldown.
        /// </summary>
        /// <returns></returns>
        public static bool SpellIsOnCooldown(int spellId)
        {
            SpellFindResults spellFindResults;
            if (SpellManager.FindSpell(spellId, out spellFindResults))
            {
                return spellFindResults.Override != null
                    ? spellFindResults.Override.Cooldown
                    : spellFindResults.Original.Cooldown;
            }

            return false;
        }

        /// <summary>
        ///     (Non-Blocking) Casts the provided spell on the provided target requiring all conditions to be satisfied prior to
        ///     casting.
        /// </summary>
        /// <returns>Returns true if the cast is successful</returns>
        public static async Task<bool> CastOnTarget(WoWUnit target, IAbility ability, List<ICondition> conditions)
        {
            foreach (var condition in conditions)
                if (!condition.Satisfied())
                {
                    if (Main.Debug && !(condition is IsOffGlobalCooldownCondition))
                    {
                        if (Main.Debug)
                        {
                            Log.Diagnostics("In " + ability + " call.");
                        }
                        if (Main.Debug)
                        {
                            Log.Diagnostics("Failed at condition: " + condition);
                        }

                        if (Main.Debug && ability is Rupture)
                        {
                            Log.Diagnostics("Has Target Rupture up? :" + target.AuraExists(ability.Spell.Id));
                        }
                        // if(Main.Debug) Log.Diagnostics("current Target: " + target);
                       
                    }
                    return false;
                }

            //Check if we should cast Ability depending on Diminishing Return

            /*
            switch (ability.DrCategory)
            {
                    
                case DrCategory.None:
                    if (Main.Debug) Log.Diagnostics("In Switchcase none");
                    break;
                case DrCategory.Disoriented:
                    {
                        if (Main.Debug) Log.Diagnostics("In Switchcase Desoriented, target : "+target.SafeName);
                        if (DiminishingReturnManager.Instance.GetDrLevel(target, DrCategory.Disoriented) >= 3)
                        {
                            Log.Combat(String.Format("Blocked {0} from Casting because Target is on Immune-DR",
                                ability.Spell.Name));
                            return false;
                        }
                        break;


                    }
            }
            
            //Check for sapped targets
            if (ability is SapAbility)
            {

                if (!UnitManager.Instance.LastSappedUnits.ContainsKey(target))
                {
                    if (!SpellManager.HasSpell(ability.Spell)) return false;
                    if (!SpellManager.CanCast(ability.Spell)) return false;
                    if (!SpellManager.Cast(ability.Spell, target)) return false;

                    Log.AppendLine(string.Format("[{0}] Casted {1} on {2}(Energy: {3}, ComboPoints: {4} HP: {5:0.##}%)",
                        ability.Category,
                        ability.Spell.Name,
                        target == null ? "Nothing" : (target.IsMe ? "Me" : target.SafeName),
                        StyxWoW.Me.CurrentEnergy,
                        StyxWoW.Me.ComboPoints,
                        StyxWoW.Me.HealthPercent
                        ), Colors.CornflowerBlue);

                    UnitManager.Instance.LastSappedUnits.Add(target, DateTime.Now + TimeSpan.FromSeconds(5));

                    await CommonCoroutines.SleepForLagDuration();

                    return true;
                } 
                //We sapped that target in the last 5 seconds, do not sap again, get another target
                return false;

            }

            */
            if (!SpellManager.HasSpell(ability.Spell)) return false;
            if (!SpellManager.CanCast(ability.Spell)) return false;
            if (!SpellManager.Cast(ability.Spell, target)) return false;

            var logColor = Colors.CornflowerBlue;

            switch (ability.Category)
            {
                case AbilityCategory.Heal:
                    logColor = Colors.Yellow;
                    break;
                case AbilityCategory.Defensive:
                    logColor = Colors.LightGreen;
                    break;
                case AbilityCategory.Buff:
                    logColor = Colors.Plum;
                    break;
            }

            {
                Log.AppendLine(string.Format("[{0}] Casted {1} on {2}(Energy: {3}, ComboPoints: {4} HP: {5:0.##}%)",
                   ability.Category,
                   ability.Spell.Name,
                   target == null ? "Nothing" : (target.IsMe ? "Me" : target.SafeName),
                   StyxWoW.Me.CurrentEnergy,
                   StyxWoW.Me.ComboPoints,
                   StyxWoW.Me.HealthPercent
                   ), logColor);
            }


            await CommonCoroutines.SleepForLagDuration();

            return true;
        }

        public static async Task<bool> DropCast(IAbility ability, WoWUnit target, List<ICondition> conditions )
        {

            foreach (var condition in conditions)
                if (!condition.Satisfied())
                {
                    if (Main.Debug) Log.Diagnostics("Failed at condition:" + condition);
                   
                    return false;
                }


            if (!SpellManager.HasSpell(ability.Spell)) return false;
            if (!SpellManager.CanCast(ability.Spell)) return false;
            if (!SpellManager.Cast(ability.Spell, target)) return false;

            if (!await Coroutine.Wait(1000, () => StyxWoW.Me.CurrentPendingCursorSpell != null))
            {
                Log.Diagnostics("Cursor didn't turn into the spell!");
                return false;
            }

            SpellManager.ClickRemoteLocation(target.Location);

            var logColor = Colors.CornflowerBlue;

            switch (ability.Category)
            {
                case AbilityCategory.Heal:
                    logColor = Colors.Yellow;
                    break;
                case AbilityCategory.Defensive:
                    logColor = Colors.LightGreen;
                    break;
                case AbilityCategory.Buff:
                    logColor = Colors.Plum;
                    break;
            }

            {
                Log.AppendLine(string.Format("[{0}] Casted {1} on {2}(Energy: {3}, ComboPoints: {4} HP: {5:0.##}%)",
                    ability.Category,
                    ability.Spell.Name,
                    target == null ? "Nothing" : (target.IsMe ? "Me" : target.SafeName),
                    StyxWoW.Me.CurrentEnergy,
                    StyxWoW.Me.ComboPoints,
                    StyxWoW.Me.HealthPercent
                    ), logColor);
            }

            await CommonCoroutines.SleepForLagDuration();
            return true;


        
        } 
    }
}