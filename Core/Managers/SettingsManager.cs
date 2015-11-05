using System;
using Styx;
using Styx.Helpers;

namespace BladeOfTheAssassin.Core.Managers
{
    /// <summary>
    /// provides Management of all Settings which are done by the user
    /// This includes things like, interrupt enabled, Talents to use, TrinketUsage and many more.
    /// </summary>
    class SettingsManager : Settings
    {

        #region singletons

        private static SettingsManager _settingsManager;

        public static SettingsManager Instance
        {
            get { return _settingsManager ?? (new SettingsManager(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile))); }
        }




        public static void Init(String pathToProfile = null)
        {
            _settingsManager = pathToProfile != null ? new SettingsManager(pathToProfile) : new SettingsManager(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile));
        }

        #endregion


        
        #region [BotA] - Shared Settings
        [Setting, DefaultValue(10)]
        public int AoeRange { get; set; }
        [Setting, DefaultValue(500)]
        public Int32 LoCDelay { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1 { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2 { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1OnLoC { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2OnLoC { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1ToBurst { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2ToBurst { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseKillingSpree { get; set; }
        [Setting, DefaultValue(false)]
        public bool KillingSpreeOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseAdrenalineRush { get; set; }
        [Setting, DefaultValue(false)]
        public bool AdrenalineRushOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseShadowDance { get; set; }
        [Setting, DefaultValue(false)]
        public bool ShadowDanceOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseShadowReflection { get; set; }
        [Setting, DefaultValue(false)]
        public bool ShadowReflectionOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool VendettaOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool ApplyPoisons { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseDeadlyPoison { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseCripplingPoison { get; set; }

        [Setting, DefaultValue(false)]
        public bool UseOrcRacial { get; set; }

        [Setting, DefaultValue(false)]
        public bool UseTrollRacial { get; set; }

        [Setting, DefaultValue(false)]
        public bool UseHumanRacial { get; set; }

        [Setting, DefaultValue(false)]
        public bool UseBloodElfRacial { get; set; }



        [Setting, DefaultValue(300)]
        public int InterruptDelay { get; set; }
        [Setting, DefaultValue(false)]
        public bool InterruptKick { get; set; }

        //Defensive
        [Setting, DefaultValue(false)]
        public bool UseRecup { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseFeint { get; set; }
        [Setting, DefaultValue(60)]
        public int RecupPercentage { get; set; }
        [Setting, DefaultValue(40)]
        public int FeintPercentage { get; set; }

        [Setting, DefaultValue(true)]
        public bool T184PEnabled { get; set; }


        #endregion

        public SettingsManager(String pathToFile)
            : base(pathToFile)
        {
        }
    }
}
