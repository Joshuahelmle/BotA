using System;
using System.Linq;
using BladeOfTheAssassin.Core.Utilities;
using Styx;
using Styx.CommonBot;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core
{
    /// <summary>
    /// Extensions added to the LocalPlayer class.
    /// </summary>
    public static class PlayerExtensions
    {
        /// <summary>
        /// Determines if the player's current target is attackable.
        /// </summary>
        public static bool HasAttackableTarget(this LocalPlayer thisPlayer)
        {
            try
            {
                return
                    thisPlayer.CurrentTarget != null &&
                    (thisPlayer.CurrentTarget.Name.ToUpper().Contains("DUMMY")) ||
                    (thisPlayer.CurrentTarget.IsValid &&
                    thisPlayer.CurrentTarget.Attackable &&
                    thisPlayer.CurrentTarget.CanSelect &&
                    !thisPlayer.CurrentTarget.IsDead);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if the player is within melee distance of the current target.
        /// </summary>
        public static bool IsWithinMeleeDistanceOfTarget(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.CurrentTarget != null &&
                thisPlayer.CurrentTarget.IsWithinMeleeRange;
        }

        /// <summary>
        /// Determines if the player is in BattleStance.
        /// </summary>
        public static bool IsInBattleStance(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.HasAura(SpellBook.StanceBattleStance);
        }

        /// <summary>
        /// Determines if the player is in DefensiveStance
        /// </summary>
        public static bool IsInDefensiveStance(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.HasAura(SpellBook.StanceDefensiveStance) ||
                thisPlayer.HasAura(SpellBook.StanceImprovedDefensiveStance);
        }

        /// <summary>
        /// Determines if the player is in GladiatorStance
        /// </summary>
        public static bool IsInGladiatorStance(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.HasAura(SpellBook.StanceGladiatorStance);
        }

        /// <summary>
        /// Determines if the player currently has stats buff: Mark of the Wild, Blessing of Kings, Legacy of Emperor, or Legacy of White Tiger
        /// </summary>
        public static bool HasAttackPowerBuff(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.HasAura(SpellBook.AuraBattleShout) ||
                thisPlayer.HasAura(SpellBook.AuraHornOfWinter) ||
                thisPlayer.HasAura(SpellBook.AuraTrueshotAura);
        }

        public static bool HasStaminaBuff(this LocalPlayer thisPlayer)
        {
            return
                thisPlayer.HasAura(SpellBook.AuraCommandingShout) ||
                thisPlayer.HasAura(SpellBook.AuraPowerWordFortitude) ||
                thisPlayer.HasAura(SpellBook.AuraBloodPact) ||
                thisPlayer.HasAura(SpellBook.AuraLoneWolfFortitudeOfTheBear);
        }
        /// <summary>
        /// Determines if the cast on the player's target can be interrupted.
        /// </summary>
        public static bool CanActuallyInterruptCurrentTargetSpellCast(this LocalPlayer thisPlayer, int milliseconds)
        {
            if (!thisPlayer.HasAttackableTarget()) return false;
            if (thisPlayer.CurrentTarget.IsChanneling && thisPlayer.ChanneledSpell != null)
            {
                return (thisPlayer.CurrentTarget.CurrentChannelTimeLeft.TotalMilliseconds > milliseconds) &&
                    (thisPlayer.CurrentTarget.CanInterruptCurrentSpellCast);
            }
            if (thisPlayer.CurrentTarget.IsCasting && thisPlayer.CurrentTarget.CastingSpell != null)
            {
                return (thisPlayer.CurrentTarget.CurrentCastTimeLeft.TotalMilliseconds > milliseconds) &&
                    (thisPlayer.CurrentTarget.CanInterruptCurrentSpellCast);
            }

            return false;
        }

        /// <summary>
        /// Determines if the player currently has lost control.
        public static bool HasLossOfControl(this LocalPlayer thisPlayer)
        {
            foreach (var aura in thisPlayer.GetAllAuras())
            {
                if (!aura.IsHarmful)
                    continue;

                if (aura.Spell == null)
                    continue;

                if (aura.Spell.Mechanic == WoWSpellMechanic.Asleep ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Charmed ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Disoriented ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Fleeing ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Horrified ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Incapacitated ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Sapped ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Stunned)
                {
                    Log.Equipment(string.Format("Loss of control detected on me: {0} ({1})", aura.Spell.Name, aura.Spell.Mechanic));
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines if the player currently has total loss of control (cannot clear).
        public static bool HasTotalLossOfControl(this LocalPlayer thisPlayer)
        {
            if (thisPlayer.HasLossOfControl()) return true;

            foreach (var aura in thisPlayer.GetAllAuras())
            {
                if (!aura.IsHarmful)
                    continue;

                if (aura.Spell == null)
                    continue;

                if (aura.Spell.Mechanic == WoWSpellMechanic.Banished ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Frozen ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Polymorphed)
                {
                    Log.Equipment(string.Format("Total Loss of control detected on me: {0} ({1})", aura.Spell.Name, aura.Spell.Mechanic));
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// <para>Determines if the player currently has a root or snare effect</para>
        /// <para>Release 1.1.0</para>
        /// </summary>
        public static bool HasRootOrSnare(this LocalPlayer thisPlayer)
        {
            foreach (var aura in thisPlayer.GetAllAuras())
            {
                if (aura.Spell.Mechanic == WoWSpellMechanic.Rooted ||
                    aura.Spell.Mechanic == WoWSpellMechanic.Snared)
                {
                    // Log.Equipment(string.Format("Snare or Root detected on me: {0} ({1})", aura.Spell.Name, aura.Spell.Mechanic));
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// Extensions added to WoWSpell spells.
    /// </summary>
    public static class SpellExtensions
    {
        /// <summary>
        /// Determines if the spell is on cooldown or not.
        /// </summary>
        public static bool IsOnCooldown(this WoWSpell thisSpell)
        {
            SpellFindResults spellFindResults;
            if (SpellManager.FindSpell(thisSpell.Id, out spellFindResults))
            {
                return spellFindResults.Override != null
                    ? spellFindResults.Override.Cooldown
                    : spellFindResults.Original.Cooldown;
            }

            return false;
        }

        /// <summary>
        /// DEtermines the remaining Cooldown of the given spell.
        /// </summary>
    public static double CooldownTimeLeft(this WoWSpell spell)
        {
             try
         {
        SpellFindResults results;
        return (SpellManager.FindSpell(spell.Id, out results) ? (results.Override != null ? results.Override.CooldownTimeLeft.TotalMilliseconds : results.Original.CooldownTimeLeft.TotalMilliseconds) : 9999) / 1000;
         }
        catch (Exception xException)
        {
        Log.Diagnostics("Exception in cooldownTimeLeft(): "+ xException);
        return 9999;
        }
        }
    }


    /// <summary>
    /// Extensions added to the BotBase class.
    /// </summary>
    public static class BotBaseExtensions
    {
        /// <summary>
        /// Determines if the current bot base is Enyo or Raid Bot.
        /// </summary>
        public static bool IsRoutineBased(this BotBase thisBotBase)
        {
            return
                thisBotBase.Name.ToUpper().Contains("ENYO") ||
                thisBotBase.Name.ToUpper().Contains("RAID BOT") ||
                thisBotBase.Name.ToUpper().Contains("HAZZ");
        }
    }

    public static class WoWUnitExtensions
    {
        public static bool AuraExists(this WoWUnit unit, int auraId, bool isMyAura = false)
        {
            try
            {
                if (unit == null || !unit.IsValid)
                    return false;
                var aura = isMyAura
                    ? unit.GetAllAuras().FirstOrDefault(a => a.SpellId == auraId && a.CreatorGuid == StyxWoW.Me.Guid)
                    : unit.GetAllAuras().FirstOrDefault(a => a.SpellId == auraId);
                return aura != null;
            }
            catch (Exception xException)
            {
                Log.Diagnostics("Exception in auraExists(): " + xException);
                return false;
            }
        }


        public static TimeSpan AuraRemainingTime(this WoWUnit unit, int auraId, bool isMyAura = false)
        {
            try
            {
                if (!AuraExists(unit, auraId, isMyAura))
                    return TimeSpan.FromSeconds(0);

                if (unit == null) return TimeSpan.FromSeconds(0);
                var aura = isMyAura
                    ? unit.GetAllAuras().First(a => a.SpellId == auraId && a.CreatorGuid == StyxWoW.Me.Guid)
                    : unit.GetAllAuras().First(a => a.SpellId == auraId);
                return aura.TimeLeft;
            }
            catch (Exception xException)
            {
                Log.Diagnostics("Exception in auraRemainingTime(): " + xException);
                return TimeSpan.FromSeconds(0);
            }
        }

        public static uint AuraStacks(this WoWUnit unit, int auraId, bool isMyAura = false)
        {
            try
            {
                if (!AuraExists(unit, auraId, isMyAura))
                    return 0;

                if (unit == null) throw new Exception("unit cannot be null!");
                WoWAura aura = isMyAura
                    ? unit.GetAllAuras().First(a => a.SpellId == auraId && a.CreatorGuid == StyxWoW.Me.Guid)
                    : unit.GetAllAuras().First(a => a.SpellId == auraId);

                return aura.StackCount;
                
            }
            catch (Exception xException)
            {
                Log.Diagnostics("Exception in AuraStacks(): " + xException);
                return 0;
            }

        }

        public static bool IsBehindOrSide(this WoWUnit unit, WoWUnit target)
        {
            return unit != null && target != null && !target.IsSafelyFacing(unit, 160);
        }

        public static double hitBoxDistance(this WoWUnit unit)
        {
            return Math.Max(0, unit.Distance - unit.BoundingRadius); 
        }
    }
}