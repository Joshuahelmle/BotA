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
            MHPoisonBox.SelectedIndex = SMInstance.Instance.UseDeadlyPoison ? 0 : 1;
            OHPoisonBox.SelectedIndex = SMInstance.Instance.UseCripplingPoison ? 0 :1;

            //Cooldowns
            UseSRCB.Checked = SMInstance.Instance.UseShadowReflection;
            SRonlyOnBossCB.Checked = SMInstance.Instance.ShadowReflectionOnlyOnBoss;
            UseSDCB.Checked = SMInstance.Instance.UseShadowDance;
            SDonlyBossCB.Checked = SMInstance.Instance.ShadowDanceOnlyOnBoss;
            UseARCB.Checked = SMInstance.Instance.UseAdrenalineRush;
            ARonlyBossCB.Checked = SMInstance.Instance.AdrenalineRushOnlyOnBoss;
            UseKSCB.Checked = SMInstance.Instance.UseKillingSpree;
            KSOnlyBossCB.Checked = SMInstance.Instance.KillingSpreeOnlyOnBoss;
            UseVendettaCb.Checked = SMInstance.Instance.UseVendetta;
            VendettaBossCB.Checked = SMInstance.Instance.VendettaOnlyOnBoss;
            AlwaysStealthCB.Checked = SMInstance.Instance.AlwaysStealth;
            UseVanish.Checked = SMInstance.Instance.UseVanish;
            VanishOnlyBoss.Checked = SMInstance.Instance.OffensiveVanishOnlyOnBoss;


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

            //Interrupts
            InterruptKickCB.Checked = SMInstance.Instance.InterruptKick;

            //Defensives
            RecupCB.Checked = SMInstance.Instance.UseRecup;
            FeintCB.Checked = SMInstance.Instance.UseFeint;
            RecupHP.Text = SMInstance.Instance.RecupPercentage.ToString();
            FeintHp.Text = SMInstance.Instance.FeintPercentage.ToString();

            //Set
            T184PCB.Checked = SMInstance.Instance.T184PEnabled;

        }

        /// <summary>
        ///     Commit any settings here
        /// </summary>
        private void CommitSettings()


        {
            //Poisons
            SMInstance.Instance.ApplyPoisons = applyPoisonsCB.Checked;
            SMInstance.Instance.UseDeadlyPoison = MHPoisonBox.SelectedIndex == 0;
            SMInstance.Instance.UseCripplingPoison = OHPoisonBox.SelectedIndex == 0;
            //Cooldowns
            SMInstance.Instance.UseShadowReflection = UseSRCB.Checked;
            SMInstance.Instance.ShadowReflectionOnlyOnBoss = SRonlyOnBossCB.Checked;
            SMInstance.Instance.UseShadowDance = UseSDCB.Checked;
            SMInstance.Instance.ShadowDanceOnlyOnBoss = SDonlyBossCB.Checked;
            SMInstance.Instance.UseAdrenalineRush = UseARCB.Checked;
            SMInstance.Instance.AdrenalineRushOnlyOnBoss = ARonlyBossCB.Checked;
            SMInstance.Instance.UseKillingSpree = UseKSCB.Checked;
            SMInstance.Instance.KillingSpreeOnlyOnBoss = KSOnlyBossCB.Checked;
            SMInstance.Instance.UseVendetta = UseVendettaCb.Checked;
            SMInstance.Instance.VendettaOnlyOnBoss = VendettaBossCB.Checked;
             SMInstance.Instance.AlwaysStealth = AlwaysStealthCB.Checked;
            SMInstance.Instance.UseVanish = UseVanish.Checked;
            SMInstance.Instance.OffensiveVanishOnlyOnBoss = VanishOnlyBoss.Checked;



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

            //Interrupts
            SMInstance.Instance.InterruptKick = InterruptKickCB.Checked;

            //Defensives
            SMInstance.Instance.UseRecup = RecupCB.Checked;
            SMInstance.Instance.UseFeint = FeintCB.Checked;
            SMInstance.Instance.RecupPercentage = Convert.ToInt32(RecupHP.Text);
            SMInstance.Instance.FeintPercentage = Convert.ToInt32(FeintHp.Text);

            //Set
            SMInstance.Instance.T184PEnabled = T184PCB.Checked;

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

     
    }
}