using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Managers;
using BladeOfTheAssassin.Core.Utilities;
using Styx;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Routines
{
    public static class Pull
    {
        
        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        private static WoWUnit MyCurrentTarget
        {
            get { return Me.CurrentTarget; }
        }

        public static async Task<bool> Rotation()
        {
            if (Me.Mounted)
            {
                if (await CommonCoroutines.Dismount()) return true;
            }
            
            return false;
        }
    }
}
