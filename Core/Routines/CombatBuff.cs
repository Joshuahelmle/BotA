using System.Diagnostics;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Shared = BladeOfTheAssassin.Core.Abilities.Shared;
using BladeOfTheAssassin.Core.Utilities;
using BladeOfTheAssassin.Core.Abilities.Assasination;
using BladeOfTheAssassin.Core.Abilities;

//using Arms = InnerRage.Core.Abilities.Arms;

namespace BladeOfTheAssassin.Core.Routines
{
    public static class CombatBuff
    {
        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        private static WoWUnit MyCurrentTarget
        {
            get { return Me.CurrentTarget; }
        }

        //  private static SettingsManager Settings { get { return SettingsManager.Instance; } }
        private static AbilityManager Abilities
        {
            get { return AbilityManager.Instance; }
        }

        private static UnitManager Units
        {
            get { return UnitManager.Instance; }
        }

        private static Stopwatch _locDelay = new Stopwatch();

        public static async Task<bool> Rotation()
        {
           if(Main.Debug) Log.Diagnostics("InCombatBuffRotationCall()");
            if (Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi) return false;

            if (BotManager.Current.IsRoutineBased() && Me.Mounted) return false;

            if (BotManager.Current.IsRoutineBased() && !Me.Combat) return false;

             if (Me.HasLossOfControl() || Me.HasTotalLossOfControl())
             {
                 if (await UseRacialToClearLoC()) return true;
                 if (await UseTrinketsToClearLoC()) return true;

             }

            #region [IR] - Trinkets

            if (await UseTrinketsToBurst()) return true;

            #endregion

            #region [IR] - Racials

            if (await Abilities.Cast<Shared.Racials.RacialOrcBloodFuryAbility>(Me)) return true;
            if (await Abilities.Cast<Shared.Racials.RacialsTrollBerserkingAbility>(Me)) return true;
            if (await Abilities.Cast<Shared.Racials.RacialsBloodElfAbility>(Me)) return true;
           

            #endregion

            return await CombatBuffRotation();
          
        }



        private static async Task<bool> CombatBuffRotation()
        {
            if(Main.Debug) Log.Diagnostics("In CombatBuffsRotation() call");
           // if (await Abilities.Cast<BurstOfSpeedAbility>(Me)) return true;
          

         //   if (await Abilities.Cast<SliceNDiceAbility>(Me)) return true;
            if (HotKeyManager.Questing)
            {
                if (await Abilities.Cast<FeintAbility>(Me)) return true;
                if (await Abilities.Cast<RecupAbility>(Me)) return true;
            }

            return false;
        }

       

        private static async Task<bool> UseRacialToClearLoC()
        {

            if(Main.Debug) Log.Diagnostics("In UseRacialToClearLoc() call");
            if (!_locDelay.IsRunning)
            {
                _locDelay.Start();
                return false;
            }
            if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
            {
                if (WoWSpell.FromId(SpellBook.RacialHumanEveryManForHimself).CooldownTimeLeft.TotalMilliseconds == 0)
                {
                    if (await Abilities.Cast<Shared.Racials.RacialHumanAbility>(Me))
                    {
                        _locDelay.Reset();
                        return true;

                    }
                       
                }
                else Log.Diagnostics("Human Racial is on Cooldown.");
                return true;

            }
            return true;
        }

        /// <summary>
        /// Checks whether we have trinkets equipped, and are allowed to use them, if so we are trying to Clear our Loss of control with them.
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> UseTrinketsToClearLoC()
        {
            if(Main.Debug) Log.Diagnostics("in UseTrinketsToClearLoC call");

            if (Me.Inventory.Equipped.Trinket1 != null)
            {
                //Use Trinkets if Settings allow it.
                if (SettingsManager.Instance.UseTrinket1)
                {
                    //Clear Loss of Control
                    if (SettingsManager.Instance.UseTrinket1OnLoC)
                    {
                        if (!_locDelay.IsRunning)
                        {
                            _locDelay.Start();
                            return true;
                        }
                        if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
                        {
                            if (Me.Inventory.Equipped.Trinket1.CooldownTimeLeft.TotalMilliseconds == 0)
                            {
                                Me.Inventory.Equipped.Trinket1.Use();
                                await CommonCoroutines.SleepForLagDuration();
                                _locDelay.Reset();
                                return true;
                            }
                            {
                                Log.Diagnostics("Trinket 1 on Cooldown.");
                            }

                        }
                    }
                }
            }

            //Trinket 2

            if (Me.Inventory.Equipped.Trinket2 != null)
            {
                //Use Trinkets if Settings allow it.
                if (SettingsManager.Instance.UseTrinket2)
                {
                    //Clear Loss of Control
                    if (SettingsManager.Instance.UseTrinket2OnLoC)
                    {

                        if (!_locDelay.IsRunning)
                        {
                            _locDelay.Start();
                            return true;
                        }
                        if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
                        {
                            if (Me.Inventory.Equipped.Trinket2.CooldownTimeLeft.TotalMilliseconds == 0)
                            {
                                Me.Inventory.Equipped.Trinket2.Use();
                                await CommonCoroutines.SleepForLagDuration();
                                _locDelay.Reset();
                                return true;
                            }
                            {
                                Log.Diagnostics("Trinket 2 on Cooldown.");
                                _locDelay.Reset();
                            }

                        }
                    }
                }
            }
            return false;
        }

        public static async Task<bool> UseTrinketsToBurst()
        {
            // use Trinket1 to burst
            if (SettingsManager.Instance.UseTrinket1ToBurst &&
                Me.Inventory.Equipped.Trinket1.CooldownTimeLeft.Milliseconds <= 0 && Me.IsWithinMeleeDistanceOfTarget())
            {
                Me.Inventory.Equipped.Trinket1.Use();
                Me.Inventory.Equipped.Trinket1.Use(MyCurrentTarget.Guid);
               await CommonCoroutines.SleepForLagDuration();
               
            }

            if (SettingsManager.Instance.UseTrinket2ToBurst &&
                Me.Inventory.Equipped.Trinket2.CooldownTimeLeft.Milliseconds <= 0 && Me.IsWithinMeleeDistanceOfTarget())
            {
                Me.Inventory.Equipped.Trinket2.Use();
                Me.Inventory.Equipped.Trinket2.Use(MyCurrentTarget.Guid);
                await CommonCoroutines.SleepForLagDuration();

            }
            return false;
        }
    }
}