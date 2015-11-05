using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Routines
{
    public static class Heal
    {
        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        private static WoWUnit MyCurrentTarget { get { return Me.CurrentTarget; } }
        private static AbilityManager Abilities { get { return AbilityManager.Instance; } }

        public static async Task<bool> Rotation()
        {
            if (Main.DeathTimer.IsRunning) Main.DeathTimer.Reset();

            if (!StyxWoW.IsInGame || !StyxWoW.IsInWorld)
                return false;

            if (Me.IsDead || Me.IsGhost || Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi || Me.Mounted)
                return false;

           // if (Me.HasTotalLossOfControl())
           //     return false;

          return await HealRotation();
        }

        private static async Task<bool> HealRotation()
        {
           // if (await Abilities.Cast<VanishDefensive>(Me)) return true;
            if (await Abilities.Cast<FeintAbility>(Me)) return true;
            if (await Abilities.Cast<RecupAbility>(Me)) return true;
            return false;
        }
    }
}