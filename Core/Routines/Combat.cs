using System.Linq;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Managers;
using BladeOfTheAssassin.Core.Utilities;
using Styx;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using BladeOfTheAssassin.Core.Abilities.Sublety;
using BladeOfTheAssassin.Core.Abilities.Assasination;
using System.Diagnostics;

namespace BladeOfTheAssassin.Core.Routines
{
    public static class Combat
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

        private static Stopwatch SRtimer = new Stopwatch();
        private static bool ruptureRefreshed = false;

        public static async Task<bool> Rotation()
        {
            if(Main.Debug) Log.Diagnostics("In CombatRotationCall()");
            if (Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi) return false;
            if (BotManager.Current.IsRoutineBased() && Me.Mounted) return false;
            //Attack after vanish  && !Me.AuraExists(SpellBook.AuraVanish))
            if (Main.Debug) Log.Diagnostics("Before Combat Check");
            if (BotManager.Current.IsRoutineBased() && (!Me.Combat && !Me.AuraExists(SpellBook.AuraVanish))) return false;
            if (Main.Debug) Log.Diagnostics("After Combat Check");

            // Clear loss of control if we can //
            //     if (await ItemManager.ClearLossOfControlWithTrinkets()) return true;

            // Don't go any further if we have total loss of control //
            //    if (Me.HasTotalLossOfControl()) return false;
/*
            if (Me.AuraExists(SpellBook.AuraVanish) && !Main.BurstTimer.IsRunning && Main.BurstTimer.ElapsedMilliseconds > 10000) return false;

            if (Main.BurstTimer.IsRunning && Main.BurstTimer.ElapsedMilliseconds < 10000)
                return await BurstRotation();
            if (!Main.BurstTimer.IsRunning || Main.BurstTimer.ElapsedMilliseconds > 10000)
                Main.BurstTimer.Reset(); */
            return await CombatRotation();
            
                }


        private static async Task<bool> CombatSpeccRotation()
        {

            if (HotKeyManager.CooldownsOn)
            {
                if (await Abilities.Cast<KillingSpree>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<AdrenalineRush>(MyCurrentTarget)) return true;
            }
            if (UnitManager.Instance.MfDTarget != null && !UnitManager.Instance.MfDTarget.IsBoss)
            {
                if (await Abilities.Cast<MarkedForDeathAbility>(UnitManager.Instance.MfDTarget)) return true;
            }
            if (await Abilities.Cast<BladeFlurryCancel>(MyCurrentTarget)) return true;
               if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true; 
               if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;
               if (await Abilities.Cast<RevealingStrikeAbility>(MyCurrentTarget)) return true;
               if (await Abilities.Cast<SinisterStrikeAbility>(MyCurrentTarget)) return true;
               return false;
        }

        private static async Task<bool> CombatSpeccAoeRotation()
        {

            if (HotKeyManager.NoAoe) return await CombatSpeccRotation();

            if (HotKeyManager.CooldownsOn)
            {
                if (await Abilities.Cast<KillingSpree>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<AdrenalineRush>(MyCurrentTarget)) return true;
            }
            if(UnitManager.Instance.MfDTarget != null && !UnitManager.Instance.MfDTarget.IsBoss)
            {
                if (await Abilities.Cast<MarkedForDeathAbility>(UnitManager.Instance.MfDTarget)) return true;
            }
            
            if (await Abilities.Cast<BladeFlurry>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RevealingStrikeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SinisterStrikeAbility>(MyCurrentTarget)) return true;
            return false;

        }
            
        private static async Task<bool> CombatRotation()
        {


            #region
            if (Me.Specialization == WoWSpec.RogueCombat)
            {
                switch (UnitManager.Instance.LastKnownEnemiesInMeeleRange.Count)
                {
                    case 0:
                        if (UnitManager.Instance.LastKnownSurroundingEnemies.Count > 0) return await CombatSpeccRotation();
                        return false;
                    case 1:
                        return await CombatSpeccRotation();
                    default:
                        return await CombatSpeccAoeRotation();
                }
            }
            #endregion

            #region Subtlety
            if (Me.Specialization == WoWSpec.RogueSubtlety)
            {
                switch (UnitManager.Instance.LastKnownEnemiesInMeeleRange.Count)
                {
                    case 0:
                        if (UnitManager.Instance.LastKnownSurroundingEnemies.Count > 0) return await SubtletySingleRotation();
                            return false;
                    case 1:
                        return await SubtletySingleRotation();
                    case 2: case 3: case 4: case 5: case 6: case 7:
                        return await SubtletyRotationTwoToFourTargets();
                    default:
                        return await SubtletyRotationAoE();
                }
            }

#endregion

            #region Assasination
            if (Me.Specialization == WoWSpec.RogueAssassination)
            {

                 switch (UnitManager.Instance.LastKnownEnemiesInMeeleRange.Count)
                {
                    case 0:
                        if (UnitManager.Instance.LastKnownSurroundingEnemies.Count > 0) return await AssassinationSingleRotation();
                        return false;
                        break;
                    case 1:
                        return await AssassinationSingleRotation();
                        break;
                    case 2:
                        return await AssassinationRotationTwoTargets();
                        break;
                    default:
                        return await AssassinationRotationAoE();
                        break;
                }

                #endregion
                return false;
            }

            return false;
        }

        #region SUBTLETYROTATIONS

        private static async Task<bool> SubtletySingleRotation()
        {
            
            
            if ((Me.CurrentTarget != null && !Me.CurrentTarget.HasAura(SpellBook.AuraFindWeakness) && !Me.AuraExists(SpellBook.AuraSubterfuge) && !Me.AuraExists(SpellBook.AuraVanish) && !Me.AuraExists(SpellBook.AuraShadowDance))
               // && (WoWSpell.FromId(SpellBook.CastVanish).CooldownTimeLeft.TotalSeconds < 10  
               //     || !WoWSpell.FromId(SpellBook.CastVanish).IsOnCooldown()
               //     || WoWSpell.FromId(SpellBook.AuraShadowDance).CooldownTimeLeft.TotalSeconds < 10)
                && StyxWoW.Me.AuraStacks(SpellBook.AuraAnticipation) < 3 
                && Me.CurrentEnergy <= 90)
                return await PoolRotation();
            
           /*
            if ((Me.CurrentTarget != null && !Me.CurrentTarget.HasAura(SpellBook.AuraFindWeakness)) && Me.AuraStacks(SpellBook.AuraAnticipation) < 3 && Me.CurrentEnergy <= 90)
            {
                return await PoolRotation();
            }
               
*/
            


            //Make sure to refresh Findweakness
            if (Me.AuraRemainingTime(SpellBook.AuraShadowDance).TotalSeconds < 1.2 || Me.AuraRemainingTime(SpellBook.AuraSubterfuge).TotalSeconds < 1.2)
                {
                    if (await Abilities.Cast<Ambush>(MyCurrentTarget)) return true;
                }

            //Cast another rupture regardless of it being already up when you use SReflection

            if (SRtimer.IsRunning && !ruptureRefreshed ){
                if (await Abilities.Cast<RefreshRupture>(MyCurrentTarget)) {
                    ruptureRefreshed = true;
                    return true;
                }
            } if (SRtimer.ElapsedMilliseconds > 16000) {
                    SRtimer.Reset();
                    ruptureRefreshed = false;
                    }
            
                 
                if (HotKeyManager.CooldownsOn)
                {
                    if (await CombatBuff.UseTrinketsToBurst()) return true;
                    if (await Abilities.Cast<ShadowReflection>(MyCurrentTarget)) {
                        SRtimer.Restart();
                        return false;
                    } 
                    if (await Abilities.Cast<ShadowDance>(Me)) return false;
                    if (await Abilities.Cast<VanishOffensive>(MyCurrentTarget)) return true;
                    if (await Abilities.Cast<Premed>(MyCurrentTarget)) return true;
                    if (await Abilities.Cast<Preperation>(Me)) return true;
                }

                if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<Rupture>(MyCurrentTarget)) return true;

                if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;


                if (await Abilities.Cast<Ambush>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<Backstab>(MyCurrentTarget)) return true; 
                if (await Abilities.Cast<Hemorrhage>(MyCurrentTarget)) return true;
                return false;

            

        }


        private static async Task<bool> SubtletyRotationTwoToFourTargets()
        {

            if (HotKeyManager.NoAoe) return await SubtletySingleRotation();

            //Make sure to refresh Findweakness
            if (Me.AuraRemainingTime(SpellBook.AuraShadowDance).TotalSeconds < 1.2)
            {
                if (await Abilities.Cast<Ambush>(MyCurrentTarget)) return true;
            }

            // if (await Abilities.Cast<VanishOffensive>(Me)) return true;
            //  if (await Abilities.Cast<Preperation>(Me)) return true;

            if (SRtimer.IsRunning && !ruptureRefreshed)
            {
                if (await Abilities.Cast<RefreshRupture>(MyCurrentTarget))
                {
                    ruptureRefreshed = true;
                    return true;
                }
            } if (SRtimer.ElapsedMilliseconds > 16000)
            {
                SRtimer.Reset();
                ruptureRefreshed = false;
            }

            if (HotKeyManager.CooldownsOn)
            {
                if (await Abilities.Cast<ShadowReflection>(MyCurrentTarget)) {
                    SRtimer.Restart();
                    return true;
                } 
                if (await Abilities.Cast<ShadowDance>(Me)) return true;
                if (await Abilities.Cast<VanishOffensive>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<Preperation>(Me)) return true;
            }    

            //Finisher
            if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Rupture>(UnitManager.Instance.LastKnownNonBleedingEnemies.FirstOrDefault())) return true;
            if (await Abilities.Cast<Rupture>(UnitManager.Instance.LastKnownBleedingEnemies.FirstOrDefault())) return true;
            if (Me.CurrentTarget.AuraExists(SpellBook.AuraFindWeakness) && UnitManager.Instance.LastKnownSurroundingEnemies.Count < 3)
            {
                if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;
            }
            if (MyCurrentTarget.AuraRemainingTime(SpellBook.AuraCrimsonTempest).TotalSeconds < 2)
            {
                if (await Abilities.Cast<CrimsonTempest>(MyCurrentTarget)) return true;
            }
            if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;
            //Generator
            if (!Me.AuraExists(SpellBook.AuraShadowDance) || UnitManager.Instance.LastKnownSurroundingEnemies.Count >= 5)
            {
                if (await Abilities.Cast<FanOfKnives>(MyCurrentTarget)) return true;
            }
            if (await Abilities.Cast<Ambush>(MyCurrentTarget)) return true;
            return false;



        }

        private static async Task<bool> SubtletyRotationAoE()
        {

            if (HotKeyManager.NoAoe) return await SubtletySingleRotation();
          
            //Finisher
            if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<CrimsonTempest>(MyCurrentTarget)) return true;
            //Generator
            if (!(Me.AuraStacks(SpellBook.AuraAnticipation) >= 1))
            {
                if (await Abilities.Cast<FanOfKnives>(MyCurrentTarget)) return true;
            }

            return false;



        }


        private static async Task<bool> PoolRotation()
        {
            if (Me.AuraStacks(SpellBook.AuraAnticipation) >= 3) return await CombatRotation();
            if (await Abilities.Cast<Rupture>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
            return true;
        }

        private static async Task<bool> PoolForDanceRotation()
        {
            if (Me.AuraStacks(SpellBook.AuraAnticipation) >= 3) return await CombatRotation();
            if (await Abilities.Cast<Rupture>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SliceNDiceAbility>(MyCurrentTarget)) return true;
            return true;
        }
#endregion

        #region ASSASSINROTATIONS

        private static async Task<bool> AssassinationSingleRotation()
        {

            /*
            if (!Me.HasAura(SpellBook.CastEnvenom) && Me.ComboPoints == 5 && (Me.CurrentTarget != null && !Me.CurrentTarget.HasAura(SpellBook.CastVendetta)) && !HotKeyManager.Questing)
            {
                return await AssasinPoolRotation();
            }
             * */
            if (HotKeyManager.CooldownsOn)
            {
                if (await Abilities.Cast<ShadowReflection>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<Vendetta>(MyCurrentTarget)) return false; // no GCD
            }

            if (await Abilities.Cast<Rupture>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Envenom>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Dispatch>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Mutilate>(MyCurrentTarget)) return true;
            return false;

        }


        private static async Task<bool> AssasinPoolRotation()
        {
            if (Main.Debug)
            {
                Log.Diagnostics("In AssasinPoolRotation() with " + Me.CurrentEnergy + " Energy.");
            }
            if (Me.CurrentEnergy >= 90 && Me.ComboPoints == 5 && MyCurrentTarget.HasAura(SpellBook.CastRupture))
            {
                if (await Abilities.Cast<Envenom>(MyCurrentTarget)) return true;
            }
            if (await Abilities.Cast<Rupture>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Dispatch>(MyCurrentTarget)) return true;
            return true;
        }


        private static async Task<bool> AssassinationRotationTwoTargets()
        {

            //NoAoe
            if (HotKeyManager.NoAoe) { return await AssassinationSingleRotation(); }

            if (!Me.HasAura(SpellBook.CastEnvenom) && Me.ComboPoints == 5 && (Me.HasAttackableTarget() && !Me.CurrentTarget.HasAura(SpellBook.CastVendetta)))
            {
                return await AssasinPoolRotation();
            }

            if (HotKeyManager.CooldownsOn)
            {
                if (await Abilities.Cast<ShadowReflection>(MyCurrentTarget)) return true;
                if (await Abilities.Cast<Vendetta>(MyCurrentTarget)) return false; // no GCD
            }

            if (await Abilities.Cast<Rupture>(UnitManager.Instance.LastKnownNonBleedingEnemies.FirstOrDefault())) return true;
            if (await Abilities.Cast<Rupture>(UnitManager.Instance.LastKnownBleedingEnemies.FirstOrDefault())) return true;
            if (UnitManager.Instance.LastKnownNotPoisonedEnemies.Count >= 1)
            {
                if (await Abilities.Cast<FanOfKnives>(MyCurrentTarget)) return true;
            }
            if (await Abilities.Cast<Envenom>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Dispatch>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Mutilate>(MyCurrentTarget)) return true;
            return false;

        }

        private static async Task<bool> AssassinationRotationAoE()
        {
            //NoAoe
            if (HotKeyManager.NoAoe) { return await AssassinationSingleRotation(); }

            if (await Abilities.Cast<AoERupture>(UnitManager.Instance.LastKnownNonBleedingEnemies.FirstOrDefault())) return true;
            if (await Abilities.Cast<AoERupture>(UnitManager.Instance.LastKnownBleedingEnemies.FirstOrDefault())) return true;
            if (UnitManager.Instance.LastKnownNotPoisonedEnemies.Count >= 1)
            {
                if (await Abilities.Cast<FanOfKnives>(MyCurrentTarget)) return true;
            }
            if (await Abilities.Cast<Envenom>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Dispatch>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<Mutilate>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<FanOfKnives>(MyCurrentTarget)) return true;

            return false;
        }

        #endregion
        private static async Task<bool> BurstRotation()
        {
            if (await Abilities.Cast<KidneyShotAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<KillingSpree>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<VanishOffensive>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<GarotteAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DeathFromAboveAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<MarkedForDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<EviscerateAbility>(MyCurrentTarget)) return true;

            return await CombatRotation();
        }

      
      
    }
}