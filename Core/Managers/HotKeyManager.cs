using System;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using Styx;
using Styx.Common;
using Styx.WoWInternals;
using FontFamily = System.Drawing.FontFamily;
using System.Windows;
using BladeOfTheAssassin.Core.Utilities;

namespace BladeOfTheAssassin.Core.Managers
{
    internal class HotKeyManager
    {
        public static bool NoAoe { get; set; }
        public static bool CooldownsOn { get; set; }
        public static bool ManualOn { get; set; }
        public static bool Questing { get; set; }
        public static bool KeysRegistered { get; set; }
        public static bool ForceAttack { get; set; }

        #region Hotkey Registration

        public static void RegisterHotKeys()
        {
            if (KeysRegistered)
                return;
            CooldownsOn = true;
            NoAoe = false;
            Questing = false;
            ForceAttack = false;

            HotkeysManager.Register("noAoe", Keys.V, ModifierKeys.Alt, ret =>
            {
                NoAoe = !NoAoe;
                StyxWoW.Overlay.AddToast((NoAoe ? "Aoe Mode Disabled" : "Aoe Mode Enabled"), 2000);
            });

            HotkeysManager.Register("CooldownsOn", Keys.G, ModifierKeys.Control, ret =>
            {
                CooldownsOn = !CooldownsOn;
                StyxWoW.Overlay.AddToast((CooldownsOn ? "BurstMode Activated!" : "BurstMode Disabled!") , 2000);
            });

            HotkeysManager.Register("Logging", Keys.L, ModifierKeys.Control, ret =>
                {
                    Main.Debug = !Main.Debug;
                    StyxWoW.Overlay.AddToast((Main.Debug ? "Logging Activated!" : "Logging Disabled!"), 2000);
                });

            HotkeysManager.Register("Quest Mode", Keys.N, ModifierKeys.Control, ret =>
            {
                Questing = !Questing;
                StyxWoW.Overlay.AddToast((Questing ? "Quest Mode Activated!" : "Quest Mode Disabled!"), 2000);
              //  QuestingLabel.setText("Questing : "+Questing.ToString());
              //  Log.Gui("Questing pressed... Questing is : " + Questing.ToString());
            });


            HotkeysManager.Register("Manual Pause", Keys.P, ModifierKeys.Control, ret =>
            {
                StyxWoW.Overlay.AddToast(("Manual Pause for 2 seconds"), 2000);
                Main.PauseTimer.Restart();
            });


            //At some fights Meelerange won't cut it (for Example Gorefiend, so just force the bot to attack)
            HotkeysManager.Register("Force Attack", Keys.L, ModifierKeys.Alt, ret =>
                {
                    StyxWoW.Overlay.AddToast(("Force Attackmode , to disable press alt + L again"), 2000);
                    ForceAttack = !ForceAttack;
                });

            

        }

        #endregion

        #region [Method] - Hotkey Removal

        public static void RemoveHotkeys()
        {
            if (!KeysRegistered)
                return;
            HotkeysManager.Unregister("noAoe");
            NoAoe = false;
            KeysRegistered = false;
            //Lua.DoString(@"print('Hotkeys: \124cFFE61515 Removed!')");
            Logging.Write(Colors.OrangeRed, "Hotkeys: Removed!");
        }

        #endregion

    }
}
