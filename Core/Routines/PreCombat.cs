using System.Diagnostics;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Managers;
using BladeOfTheAssassin.Core.Utilities;
using Styx;
using Styx.WoWInternals.WoWObjects;


namespace BladeOfTheAssassin.Core.Routines
{
    public static class PreCombat
    {
        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        private static WoWUnit MyCurrentTarget { get { return Me.CurrentTarget; } }
        private static AbilityManager Abilities { get { return AbilityManager.Instance; } }

        /// <summary>
        /// Buff after a 5 second pulse timer so we don't appear like an automated program that zones in and immediately buffs.
        /// </summary>
        public const int BuffTimerIntervalMs = 5000;
        private static Stopwatch _buffTimer = new Stopwatch();

        public static async Task<bool> Rotation()
        {
            if (Main.DeathTimer.IsRunning) Main.DeathTimer.Reset();

            if (!_buffTimer.IsRunning) _buffTimer.Start();

            // Checking if auras are greater than 0 helps with the bot to stop rebuffing immediately after zoning in
            // because the bot has a very small window after loading the character when it's loaded but does not know about
            // the character auras yet (aura count is 0). // Even if we don't have any visible buffs up, the character likely has over 10 "invisible" auras
            if ((_buffTimer.ElapsedMilliseconds >= BuffTimerIntervalMs) && Me.Auras.Count > 0)
            {
                _buffTimer.Restart();

                if (Me.IsDead || Me.IsGhost || Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi || Me.Mounted)
                    return false;


                //return await DpsPreCombatRotation();
                
            }

            if (Me.IsDead || Me.IsGhost || Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi || Me.Mounted)
                return false;

            if (Main.Debug)
            {
                Log.Diagnostics("In PreCombatRotationCall()");
            }

            /*
            if (await Abilities.Cast<StealthAbility>(Me)) return true;
            //if (await Abilities.Cast<SapAbility>(MyCurrentTarget)) return true;
            //if (await Abilities.Cast<SapAbility>(UnitManager.Instance.SapTarget)) return true;
           if ((Me.Specialization == WoWSpec.RogueCombat)){
            if (await Abilities.Cast<InstantPoison>(Me)) return true;
           }
           else { if (await Abilities.Cast<DeadlyPoison>(Me)) return true;}

            if (await Abilities.Cast<CripplingPoison>(Me)) return true;
            if (Me.Specialization == WoWSpec.RogueSubtlety && (Me.Combat || HotKeyManager.Questing || Me.AuraExists(SpellBook.AuraVanish)))
            {
                return await Combat.Rotation();
            }
           
          //  if (await Abilities.Cast<BurstOfSpeedAbility>(Me)) return true;
        */
            return false;
        }


        

       
    }
}