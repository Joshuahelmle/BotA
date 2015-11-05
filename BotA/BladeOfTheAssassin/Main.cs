using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core;
using BladeOfTheAssassin.Core.Managers;
using CommonBehaviors.Actions;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Routines;
using Styx.WoWInternals.WoWObjects;
using R = BladeOfTheAssassin.Core.Routines;
using BladeOfTheAssassin.Core.Utilities;
using Styx.CommonBot.Coroutines;
using GlobalSettings = BladeOfTheAssassin.Core.Managers.GlobalSettings;
using Styx.TreeSharp;
using Styx.WoWInternals;
using BladeOfTheAssassin.Interface;
using System.Windows.Forms;

namespace BladeOfTheAssassin
{
   /// <summary>
    /// Main entry point into the custom combat routine.
    /// </summary>
    public class Main : CombatRoutine
    {
        /// <summary>
        /// used to log debug Messages, defaults to false.
        /// </summary>
        public static bool Debug = false;
        private static Version _version = new Version(1, 0, 0);

        public static Version Version { get { return _version; } }
        public static Stopwatch DeathTimer = new Stopwatch();
        public static Stopwatch BurstTimer = new Stopwatch();
        public static Stopwatch PauseTimer = new Stopwatch();

        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        private static WoWUnit MyCurrentTarget { get { return Me.CurrentTarget; } }
        public override WoWClass Class { get { return WoWClass.Rogue; } }
        public override string Name { get { return string.Format("Blade of the Assassin (Beta) (v{0})", Version); } }
        public override bool WantButton { get { return true; } }
        public override bool NeedDeath { get { return !BotManager.Current.IsRoutineBased() && Me.IsDead && !Me.IsGhost; } }
        public WoWSpec MyCurrentSpec { get; set; }



        public override Composite PreCombatBuffBehavior { get  { return new ActionRunCoroutine(o => R.PreCombat.Rotation()); } }
        public override Composite PullBehavior { get { return new ActionRunCoroutine(o => R.Pull.Rotation()); } }
        public override Composite CombatBehavior { get { return new ActionRunCoroutine(o => R.Combat.Rotation()); } }
        public override Composite HealBehavior { get { return new ActionRunCoroutine(o => R.Heal.Rotation()); } }
        public override Composite CombatBuffBehavior
        { get { return new ActionRunCoroutine(o => R.CombatBuff.Rotation()); } }
        // public override Composite RestBehavior { get { return new ActionRunCoroutine(o => R.Rest.Rotation()); } }



        public override void Initialize()
        {
            try
            {
                this.MyCurrentSpec = Me.Specialization;
                HotKeyManager.RegisterHotKeys();
                GlobalSettings.Instance.Init();
                SettingsManager.Init();
                AbilityManager.ReloadAbilities();

                Log.Combat("--------------------------------------------------");
                Log.Combat(Name);
                Log.Combat(string.Format("You are a Level {0} {1} {2}", Me.Level, Me.Race, Me.Class));
                Log.Combat(string.Format("Current Specialization: {0}", this.MyCurrentSpec.ToString().Replace("Rogue", string.Empty)));
                Log.Combat(string.Format("Current Profile: {0}", GlobalSettings.Instance.LastUsedProfile));
                Log.Combat(string.Format("{0} abilities loaded", AbilityManager.Instance.Abilities.Count));
                Log.Combat("--------------------------------------------------");
              //  HotKeyManager.RegisterHotKeys();
               // DiminishingReturnManager.Instance.Init();
            }
            catch (Exception ex)
            {
                Log.Gui(string.Format("Error Initializing Blade of the Assassin Combat Routine: {0}", ex));
            }
        }

        public override void Pulse()
        {

            //Manual CastPause for 2 seconds

            if (PauseTimer.IsRunning)
            {
                if (PauseTimer.ElapsedMilliseconds >= 2000)
                {
                    PauseTimer.Reset();
                }
                return;
            }



            if(Main.Debug)Log.Diagnostics("In Main.Pulse()");
            if (MyCurrentSpec != Me.Specialization)
            {
                Log.Combat(string.Format("Specialization changed from {0} to {1}", MyCurrentSpec.ToString().Replace("Rogue", string.Empty), Me.Specialization.ToString().Replace("Rogue", string.Empty)));
                this.MyCurrentSpec = Me.Specialization;
            }
            
          

            AbilityManager.Instance.Update();
            UnitManager.Instance.Update();
          //  DiminishingReturnManager.Instance.Update(); //possible bottleneck in big enviroments.

            base.Pulse();
        }

        public override void OnButtonPress()
        {
            var settingsForm = new Settings();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // SettingsManager.Init(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile));
                AbilityManager.ReloadAbilities();
                // ItemManager.LoadDataSet();

                Log.Gui(string.Format("Profile saved and loaded."));
            }
        }
}
}
