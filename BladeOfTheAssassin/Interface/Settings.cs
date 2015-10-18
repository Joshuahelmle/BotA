/* CREDIT : UI Skeleton and  vertical tabs from Hackersrage Thread
 * https://www.thebuddyforum.com/honorbuddy-forum/community-developer-forum/201626-4k-resolution-skinned-form-plugin-sample.html 
 * Thanks a lot! */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BladeOfTheAssassin.Core.Managers;
using BladeOfTheAssassin.Core.Utilities;
using SMInstance = BladeOfTheAssassin.Core.Managers.SettingsManager;

// Honorbuddy includes

namespace BladeOfTheAssassin.Interface
{
    public partial class Settings : Form
    {
        private void loadBTN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var pathToFile = GlobalSettings.GetFullPathToProfile(openFileDialog1.FileName);
                SettingsManager.Init(pathToFile);
                InitSettings();
                SettingsManager.Instance.Save();
                GlobalSettings.Instance.Save();
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CommitSettings();
                var pathToFile = GlobalSettings.GetFullPathToProfile(saveFileDialog1.FileName);

                SettingsManager.Instance.SaveToFile(pathToFile);
                SettingsManager.Instance.Save();
                GlobalSettings.Instance.LastUsedProfile = saveFileDialog1.FileName;
                GlobalSettings.Instance.Save();
            }
        }

        private void useSettingsBTN_Click(object sender, EventArgs e)
        {
            CommitSettings();
            SettingsManager.Instance.Save();
            GlobalSettings.Instance.Save();

            DialogResult = DialogResult.OK;
        }

        private void FormHeaderClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        #region FormInitialize

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // Set the version to display on the label
            var ver = Main.Version;
            lblVersion.Text = String.Format("v{0}", ver);


            LoadIntroduction();


            // Load user settings
            InitSettings();
            openFileDialog1.InitialDirectory = Path.Combine(Styx.Helpers.Settings.CharacterSettingsDirectory,
                "BladeOfTheAssassin");
            saveFileDialog1.InitialDirectory = Path.Combine(Styx.Helpers.Settings.CharacterSettingsDirectory,
                "BladeOfTheAssassin");
        }

        private void LoadIntroduction()
        {
            try
            {
                rtfAbout.LoadFile(@"Routines\BladeOfTheAssassin\Resources\release-notes.rtf");
            }
            catch
            {
                rtfAbout.Text =
                    "Unable to load the release notes. Ensure that the path looks like this:\n\n.\\Routines\\BladeOfTheAssassin\\Resources\\release-notes.rtf\n\n" +
                    "It may also be possible that you have the release notes open in an external editor such as Microsoft Word.";
            }
        }

        #endregion

        #region Settings

        /// <summary>
        ///     Load any settings here
        /// </summary>
        private void InitSettings()
        {

            //Poisons
            applyPoisonsCB.Checked = SMInstance.Instance.ApplyPoisons;

            //Cooldowns
            UseSRCB.Checked = SMInstance.Instance.UseShadowReflection;
            SRonlyOnBossCB.Checked = SMInstance.Instance.ShadowReflectionOnlyOnBoss;
            UseSDCB.Checked = SMInstance.Instance.UseShadowDance;
            SDonlyBossCB.Checked = SMInstance.Instance.ShadowDanceOnlyOnBoss;
            UseARCB.Checked = SMInstance.Instance.UseAdrenalineRush;
            ARonlyBossCB.Checked = SMInstance.Instance.AdrenalineRushOnlyOnBoss;
            UseKSCB.Checked = SMInstance.Instance.UseKillingSpree;
            KSOnlyBossCB.Checked = SMInstance.Instance.KillingSpreeOnlyOnBoss;


            //Trinkets
            Trinket1CB.Checked = SMInstance.Instance.UseTrinket1;
            Trinket1LoCCB.Checked = SMInstance.Instance.UseTrinket1OnLoC;
            Trinket2BurstCb.Checked = SMInstance.Instance.UseTrinket1ToBurst;

            Trinket2CB.Checked = SMInstance.Instance.UseTrinket2;
            Trinket2LoCCB.Checked = SMInstance.Instance.UseTrinket2OnLoC;
            Trinket2BurstCb.Checked = SMInstance.Instance.UseTrinket2ToBurst;

            //Racials

            RacialOrcCB.Checked = SMInstance.Instance.UseOrcRacial;
            RacialOrcCB.Checked = SMInstance.Instance.UseTrollRacial;
            RacialHumanCB.Checked = SMInstance.Instance.UseHumanRacial;
            RacialBloodElfCB.Checked = SMInstance.Instance.UseBloodElfRacial;

            //Timer

            InterruptDelay.Text = SMInstance.Instance.InterruptDelay.ToString();
            LoCDelay.Text = SMInstance.Instance.LoCDelay.ToString();

            /*
            //Buffs
            checkBuffs.Checked = SMInstance.Instance.BuffEnabled;
            BuffComboBox.SelectedIndex = SMInstance.Instance.BuffCommandingShout ? 1 : 0;

            //Interrupts
            InterruptPummelCB.Checked = SMInstance.Instance.InterruptPummel;
            InterruptShockWaveCB.Checked = SMInstance.Instance.InterruptShockWave;
            InterruptStormBoltCB.Checked = SMInstance.Instance.InterruptStormBolt;

            //Talents
            TalentAvatarCB.Checked = SMInstance.Instance.TalentAvatar;
            TalentsBloodBathCB.Checked = SMInstance.Instance.TalentBloodBath;
            TalentBladeStormCB.Checked = SMInstance.Instance.TalentBladeStorm;
            TalentDragonRoarCB.Checked = SMInstance.Instance.TalentDragonRoar;
            TalentShockWaveCB.Checked = SMInstance.Instance.TalentShockWave;
            TalentStormBoltCB.Checked = SMInstance.Instance.TalentStormBolt;
            TalentRavagerCB.Checked = SMInstance.Instance.TalentRavager;


            TalentsBloodBathCondition.SelectedIndex = SMInstance.Instance.TalentBloodbathAlways ? 0 : 1;
            if (SMInstance.Instance.TalentRecklessnessAlways)
                TalentsRecklessnessCondition.SelectedIndex = 0;
            else if (SMInstance.Instance.TalentRecklessnessOnBloodBath)
                TalentsRecklessnessCondition.SelectedIndex = 1;
            else TalentsRecklessnessCondition.SelectedIndex = 2;
            TalentSyncAvatar.Checked = SMInstance.Instance.TalentSyncAvatar;
            TalentSyncDragonRoar.Checked = SMInstance.Instance.TalentSyncDragonRoar;

            TalentSyncRavager.Checked = SMInstance.Instance.TalentSyncRavager;
            TrinketAura.Text = Convert.ToString(SMInstance.Instance.TrinketProccAura);
            RecklessnessOnlyOnBossCB.Checked = SMInstance.Instance.RecklessOnlyOnBoss;


            //Trinkets
            Trinket1CB.Checked = SMInstance.Instance.UseTrinket1;
            Trinket1LoCCB.Checked = SMInstance.Instance.UseTrinket1OnLoC;
            Trinket2BurstCb.Checked = SMInstance.Instance.UseTrinket1ToBurst;

            Trinket2CB.Checked = SMInstance.Instance.UseTrinket2;
            Trinket2LoCCB.Checked = SMInstance.Instance.UseTrinket2OnLoC;
            Trinket2BurstCb.Checked = SMInstance.Instance.UseTrinket2ToBurst;

            //Racials

            RacialOrcCB.Checked = SMInstance.Instance.UseOrcRacial;
            RacialOrcCB.Checked = SMInstance.Instance.UseTrollRacial;
            RacialHumanCB.Checked = SMInstance.Instance.UseHumanRacial;
            RacialBloodElfCB.Checked = SMInstance.Instance.UseBloodElfRacial;

            //Timer

            InterruptDelay.Text = SMInstance.Instance.InterruptDelay.ToString();
            LoCDelay.Text = SMInstance.Instance.LoCDelay.ToString();


            //Talents - Advanced
            BladestormOnlyBossCB.Checked = SMInstance.Instance.BladestormOnlyOnBoss;
            BladestormOnlyAoECountCB.Checked = SMInstance.Instance.BladestormOnlyOnAoECount;
            BladestormAoECount.Text = SMInstance.Instance.BladestormAoeCount.ToString();

            RavagerOnlyBossCB.Checked = SMInstance.Instance.RavagerOnlyOnBoss;
            RavagerOnlyAoECountCB.Checked = SMInstance.Instance.RavagerOnlyOnAoECount;
            RavagerAoeCount.Text = SMInstance.Instance.RavagerAoeCount.ToString();

            DragonRoarOnlyOnBossCB.Checked = SMInstance.Instance.DragonRoarOnlyOnBoss;
            DragonRoarAoECountCB.Checked = SMInstance.Instance.DragonRoarOnlyOnAoECount;
            DragonRoarAoECount.Text = SMInstance.Instance.DragonRoarAoeCount.ToString();

            BerserkerBreakFearCB.Checked = SMInstance.Instance.UseBerserkerBreakFear;

            EnragedRegenerationCB.Checked = SMInstance.Instance.UseEnragedRegeneration;
            RallyingCryCB.Checked = SMInstance.Instance.UseRallyingCry;
            RallyingCryHP.Text = SMInstance.Instance.RallyingCryHP.ToString();
            DieByTheSwordCB.Checked = SMInstance.Instance.UseDieByTheSword;
            DBTSHP.Text = SMInstance.Instance.UseDieByTheSwordHP.ToString();
            UseLastStandCB.Checked = SMInstance.Instance.UseLastStand;
            UseLastStandHP.Text = SMInstance.Instance.UseLastStandHP.ToString();
            UseShieldWallCB.Checked = SMInstance.Instance.UseShieldWall;
            UseShieldWallHP.Text = SMInstance.Instance.UseShieldWallHP.ToString(); 

            if (Main.Debug)
            {
                Log.Diagnostics("You are in InitSettings:");
                Log.Diagnostics(" SMInstance.Instance.BuffEnabled: " + SMInstance.Instance.BuffEnabled);
                Log.Diagnostics(String.Format(" SMInstance.Instance.DieByTheSword : {0} , on {1} HP",
                    SMInstance.Instance.UseDieByTheSword,
                    SMInstance.Instance.UseDieByTheSwordHP));
                Log.Diagnostics(String.Format("SMInstance.Instance.Bladestorm only on AoECount : {0} , on {1} Targets",
                    SMInstance.Instance.BladestormOnlyOnAoECount,
                    SMInstance.Instance.BladestormAoeCount));
                Log.Diagnostics(String.Format("SMInstance.Instance.Bladestorm only on Boss : {0}",
                    SMInstance.Instance.BladestormOnlyOnBoss
                    ));
            }
             */
        }

        /// <summary>
        ///     Commit any settings here
        /// </summary>
        private void CommitSettings()


        {
            //Poisons
            SMInstance.Instance.ApplyPoisons = applyPoisonsCB.Checked;

            //Cooldowns
            SMInstance.Instance.UseShadowReflection = UseSRCB.Checked;
            SMInstance.Instance.ShadowReflectionOnlyOnBoss = SRonlyOnBossCB.Checked;
            SMInstance.Instance.UseShadowDance = UseSDCB.Checked;
            SMInstance.Instance.ShadowDanceOnlyOnBoss = SDonlyBossCB.Checked;
            SMInstance.Instance.UseAdrenalineRush = UseARCB.Checked;
            SMInstance.Instance.AdrenalineRushOnlyOnBoss = ARonlyBossCB.Checked;
            SMInstance.Instance.UseKillingSpree = UseKSCB.Checked;
            SMInstance.Instance.KillingSpreeOnlyOnBoss = KSOnlyBossCB.Checked;

            //Trinkets
            SMInstance.Instance.UseTrinket1 = Trinket1CB.Checked;
            SMInstance.Instance.UseTrinket1OnLoC = Trinket1LoCCB.Checked;
            SMInstance.Instance.UseTrinket1ToBurst = Trinket2BurstCb.Checked;

            SMInstance.Instance.UseTrinket2 = Trinket2CB.Checked;
            SMInstance.Instance.UseTrinket2OnLoC = Trinket2LoCCB.Checked;
            SMInstance.Instance.UseTrinket2ToBurst = Trinket2BurstCb.Checked;

            //Racials

            SMInstance.Instance.UseOrcRacial = RacialOrcCB.Checked;
            SMInstance.Instance.UseTrollRacial = RacialOrcCB.Checked;
            SMInstance.Instance.UseHumanRacial = RacialHumanCB.Checked;
            SMInstance.Instance.UseBloodElfRacial = RacialBloodElfCB.Checked;


            //Timer

            SMInstance.Instance.InterruptDelay = Convert.ToInt32(InterruptDelay.Text);
            SMInstance.Instance.LoCDelay = Convert.ToInt32(LoCDelay.Text);
            /*
            SMInstance.Instance.BuffEnabled = checkBuffs.Checked;
            SMInstance.Instance.BuffBattleshout = BuffComboBox.SelectedIndex == 0;
            SMInstance.Instance.BuffCommandingShout = BuffComboBox.SelectedIndex == 1;

            //Interrupts
            SMInstance.Instance.InterruptPummel = InterruptPummelCB.Checked;

            SMInstance.Instance.InterruptStormBolt = InterruptStormBoltCB.Checked;
            SMInstance.Instance.InterruptShockWave = InterruptShockWaveCB.Checked;

            //Talents
            SMInstance.Instance.TalentAvatar = TalentAvatarCB.Checked;

            SMInstance.Instance.TalentBloodBath = TalentsBloodBathCB.Checked;
            SMInstance.Instance.TalentBladeStorm = TalentBladeStormCB.Checked;
            SMInstance.Instance.TalentDragonRoar = TalentDragonRoarCB.Checked;
            SMInstance.Instance.TalentShockWave = TalentShockWaveCB.Checked;
            SMInstance.Instance.TalentStormBolt = TalentStormBoltCB.Checked;
            SMInstance.Instance.TalentRavager = TalentRavagerCB.Checked;

            SMInstance.Instance.TalentBloodbathAlways = TalentsBloodBathCondition.SelectedIndex == 0;
            SMInstance.Instance.TalentBloodbathOnTrinket = TalentsBloodBathCondition.SelectedIndex == 1;
            SMInstance.Instance.TalentRecklessnessAlways = TalentsRecklessnessCondition.SelectedIndex == 0;
            SMInstance.Instance.TalentRecklessnessOnBloodBath = TalentsRecklessnessCondition.SelectedIndex == 1;
            SMInstance.Instance.TalentRecklessnessNever = TalentsRecklessnessCondition.SelectedIndex == 2;

            SMInstance.Instance.TalentSyncAvatar = TalentSyncAvatar.Checked;
            SMInstance.Instance.TalentSyncDragonRoar = TalentSyncDragonRoar.Checked;

            SMInstance.Instance.TalentSyncRavager = TalentSyncRavager.Checked;

            SMInstance.Instance.TrinketProccAura = Convert.ToInt32(TrinketAura.Text);

            SMInstance.Instance.RecklessOnlyOnBoss = RecklessnessOnlyOnBossCB.Checked;


            //Trinkets
            SMInstance.Instance.UseTrinket1 = Trinket1CB.Checked;
            SMInstance.Instance.UseTrinket1OnLoC = Trinket1LoCCB.Checked;
            SMInstance.Instance.UseTrinket1ToBurst = Trinket2BurstCb.Checked;

            SMInstance.Instance.UseTrinket2 = Trinket2CB.Checked;
            SMInstance.Instance.UseTrinket2OnLoC = Trinket2LoCCB.Checked;
            SMInstance.Instance.UseTrinket2ToBurst = Trinket2BurstCb.Checked;

            //Racials

            SMInstance.Instance.UseOrcRacial = RacialOrcCB.Checked;
            SMInstance.Instance.UseTrollRacial = RacialOrcCB.Checked;
            SMInstance.Instance.UseHumanRacial = RacialHumanCB.Checked;
            SMInstance.Instance.UseBloodElfRacial = RacialBloodElfCB.Checked;


            //Timer

            SMInstance.Instance.InterruptDelay = Convert.ToInt32(InterruptDelay.Text);
            SMInstance.Instance.LoCDelay = Convert.ToInt32(LoCDelay.Text);


            //Talents - Advanced
            SMInstance.Instance.BladestormOnlyOnBoss = BladestormOnlyBossCB.Checked;
            SMInstance.Instance.BladestormOnlyOnAoECount = BladestormOnlyAoECountCB.Checked;
            SMInstance.Instance.BladestormAoeCount = Convert.ToInt32(BladestormAoECount.Text);

            SMInstance.Instance.RavagerOnlyOnBoss = RavagerOnlyBossCB.Checked;
            SMInstance.Instance.RavagerOnlyOnAoECount = RavagerOnlyAoECountCB.Checked;
            SMInstance.Instance.RavagerAoeCount = Convert.ToInt32(RavagerAoeCount.Text);

            SMInstance.Instance.DragonRoarOnlyOnBoss = DragonRoarOnlyOnBossCB.Checked;
            SMInstance.Instance.DragonRoarOnlyOnAoECount = DragonRoarAoECountCB.Checked;
            SMInstance.Instance.DragonRoarAoeCount = Convert.ToInt32(DragonRoarAoECount.Text);

            SMInstance.Instance.UseBerserkerBreakFear = BerserkerBreakFearCB.Checked;
            SMInstance.Instance.UseEnragedRegeneration = EnragedRegenerationCB.Checked;
            SMInstance.Instance.UseRallyingCry = RallyingCryCB.Checked;
            SMInstance.Instance.RallyingCryHP = Convert.ToInt32(RallyingCryHP.Text);
            SMInstance.Instance.UseDieByTheSword = DieByTheSwordCB.Checked;
            SMInstance.Instance.UseDieByTheSwordHP = Convert.ToInt32(DBTSHP.Text);

            SMInstance.Instance.UseLastStand = UseLastStandCB.Checked;
            SMInstance.Instance.UseLastStandHP = Convert.ToInt32(UseLastStandHP.Text);
            SMInstance.Instance.UseShieldWall = UseShieldWallCB.Checked;
            SMInstance.Instance.UseShieldWallHP = Convert.ToInt32(UseShieldWallHP.Text);


            if (Main.Debug) // debug
            {
                Log.Diagnostics("You are in CommitSettings:");
                Log.Diagnostics(" SMInstance.Instance.BuffEnabled: " + SMInstance.Instance.BuffEnabled);
                Log.Diagnostics(String.Format(" SMInstance.Instance.DieByTheSword : {0} , on {1} HP",
                    SMInstance.Instance.UseDieByTheSword,
                    SMInstance.Instance.UseDieByTheSwordHP));
            }
             */
        }

        #endregion

        #region CustomUX

        private void Settings_Dispose(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Custom form drag and close handler.
        /// </summary>
        private Point _formHeaderCursorPosition;

        private void FormHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _formHeaderCursorPosition = new Point(-e.X, -e.Y);
        }

        private void FormHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var mousePos = MousePosition;
                mousePos.Offset(_formHeaderCursorPosition.X, _formHeaderCursorPosition.Y);
                Location = mousePos;
            }
        }

        private void FormHeaderClose_Click(object sender, EventArgs e)
        {
            Hide();
            CommitSettings();
        }

        /// <summary>
        ///     Resize a borderless form. It does have flicker on resize, but the form sizes.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                var x = (int) (m.LParam.ToInt64() & 0xFFFF);
                var y = (int) ((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                var pt = PointToClient(new Point(x, y));
                var clientSize = ClientSize;
                ///allow resize on the lower right corner
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }

                ///allow resize on the lower left corner
                if (pt.X <= 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (IsMirrored ? htBottomRight : htBottomLeft);
                    return;
                }

                ///allow resize on the upper right corner
                if (pt.X <= 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (IsMirrored ? htTopRight : htTopLeft);
                    return;
                }

                ///allow resize on the upper left corner
                if (pt.X >= clientSize.Width - 16 && pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (IsMirrored ? htTopLeft : htTopRight);
                    return;
                }

                ///allow resize on the top border
                if (pt.Y <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (htTop);
                    return;
                }

                ///allow resize on the bottom border
                if (pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (htBottom);
                    return;
                }

                ///allow resize on the left border
                if (pt.X <= 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (htLeft);
                    return;
                }

                ///allow resize on the right border
                if (pt.X >= clientSize.Width - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr) (htRight);
                    return;
                }
            }

            base.WndProc(ref m);
        }

        #endregion

        private void tabSettings_Click(object sender, EventArgs e)
        {

        }


    }
}