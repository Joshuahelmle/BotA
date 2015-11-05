/* CREDIT : Almost all of the code in this class is Work of SnowCrash , thanks for giving me insight and creative ideas buddy! */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Abilities;
using BladeOfTheAssassin.Core.Abilities.Combat;
using BladeOfTheAssassin.Core.Abilities.Shared.Racials;
using BladeOfTheAssassin.Core.Utilities;
using Styx.WoWInternals.WoWObjects;
using BladeOfTheAssassin.Core.Abilities.Sublety;
using BladeOfTheAssassin.Core.Abilities.Assasination;

//using Arms = InnerRage.Core.Abilities.Arms;
//using Fury = InnerRage.Core.Abilities.Fury;

namespace BladeOfTheAssassin.Core.Managers
{
    /// <summary>
    /// Provides the management of loaded abilities.
    /// </summary>
    public sealed class AbilityManager
    {
        #region [IR] Singletons

        private static AbilityManager _singletonInstance;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static AbilityManager Instance
        {
            get
            {
                return _singletonInstance ?? (_singletonInstance = new AbilityManager());
            }
        }

        /// <summary>
        /// Rebuilds and reloads all of the abilities. Is used after changing Talents, or Specc
        /// </summary>
        public static void ReloadAbilities()
        {
            _singletonInstance = new AbilityManager();
        }

        #endregion

        /// <summary>
        /// The amount of time to elapse in order to presume an ability has been casted too quickly after it has been already previously casted.
        /// </summary>
        public const int CastTryElapsedTimeMs = 500;

        /// <summary>
        /// The number of times allowed to cast an ability before it has been blocked after a consecutive attempt.
        /// </summary>
        public const int CastTryThreshold = 2;

        /// <summary>
        /// The length of time in Milliseconds to block an ability before it is allowed to be cast again.
        /// </summary>
        public const int BlockTimeMs = 1000;

        /// <summary>
        /// Gets the last casted ability.
        /// </summary>
        public IAbility LastCastAbility { get; private set; }

        /// <summary>
        /// Gets the time of the last casted ability.
        /// </summary>
        public DateTime LastCastDateTime { get; private set; }

        /// <summary>
        /// Gets the number of successful cast attempts for the last casted ability.
        /// </summary>
        public int LastCastTries { get; private set; }

        /// <summary>
        /// Gets the list of loaded abilities.
        /// </summary>
        public List<IAbility> Abilities { get; private set; }

        /// <summary>
        /// Gets the list of abilities that are currently blocked.
        /// </summary>
        public BlockedAbilityList BlockedAbilities { get; private set; }

        /// <summary>
        /// Updates each loaded ability. This should only be done during the Main.Pulse().
        /// </summary>
        public void Update()
        {
            foreach (IAbility ability in Abilities)
            {
                ability.Update();
            }
        }

        /// <summary>
        /// <para>(Non-Blocking) Casts the specified ability on the provided target. Also generates logging and audit information.</para>
        /// <para>This is the perferred entry point to casting an ability's spell, as it manages the logic behind blocked abilities</para>
        /// </summary>
        /// <returns>Will return true if the cast was successful.</returns>
        public async Task<bool> Cast<T>(WoWUnit target) where T : IAbility
        {


            var abilities = Get<T>();


            if (abilities == null || abilities.Count == 0)
                throw new AbilityException("Ability does not exist.");

            foreach (var ability in abilities)
            {

                var blockedAbility = this.BlockedAbilities.GetBlockedAbilityByType(ability.GetType());
                if (blockedAbility != null)
                {
                    var blockedTimeInMs = (DateTime.Now - blockedAbility.BlockedDateAndTime).TotalMilliseconds;
                    if (blockedTimeInMs >= BlockTimeMs)
                    {
                        this.BlockedAbilities.Remove(blockedAbility);
                        Log.Diagnostics(string.Format("Blocked ability {0} removed after {1} ms.", ability.Spell.Name, blockedTimeInMs));
                    }
                    else
                    {
                        // The ability is blocked, do not cast.
                        return false;
                    }
                }


               
                
                ability.Target = target;
                var castResult = await ability.CastOnTarget(target);

                if (castResult)
                {
                    if (ability == this.LastCastAbility) // This ability was already casted before, has it been less than the threshold minimum?
                    {
                        var lastCastTimeInMs = (DateTime.Now - this.LastCastDateTime).TotalMilliseconds;
                        if (lastCastTimeInMs < CastTryElapsedTimeMs)
                        {
                            if (this.LastCastTries >= CastTryThreshold)
                            {
                                this.BlockedAbilities.Add(new BlockedAbility(ability, DateTime.Now));
                                Log.Diagnostics(string.Format("{0} has been blocked after {1} cast atttempts. Total of {2} blocked abilities.", ability.GetType().Name, this.LastCastTries + 1, this.BlockedAbilities.Count));

                                return false;
                            }
                            else
                            {
                                this.LastCastTries++;
                            }
                        }
                    }
                    else
                    {
                        this.LastCastTries = 1;
                    }

                    this.LastCastAbility = ability;
                    this.LastCastDateTime = DateTime.Now;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the current instance of the specified ability class.
        /// </summary>
        public List<IAbility> Get<T>() where T : IAbility
        {
            return this.Abilities
                .Where(o => o is T)
                .ToList();
        }

        /// <summary>
        /// Builds the list of abilities on creation.
        /// </summary>
        public AbilityManager()
        {
            this.Abilities = new List<IAbility>();
            this.BlockedAbilities = new BlockedAbilityList();

            Abilities.Add(new Ambush());
            Abilities.Add(new Backstab());
            Abilities.Add(new BurstOfSpeedAbility());
            Abilities.Add(new CheapShotAbility());
            Abilities.Add(new CloakOfShadowsAbility());
            Abilities.Add(new CripplingPoison());
            Abilities.Add(new CrimsonTempest());
            Abilities.Add(new DeadlyPoison());
            Abilities.Add(new Dispatch());
            Abilities.Add(new Preperation());
            Abilities.Add(new DeathFromAboveAbility());
            Abilities.Add(new Envenom());
            Abilities.Add(new BladeFlurry());
            Abilities.Add(new BladeFlurryCancel());
            Abilities.Add(new AdrenalineRush());
            Abilities.Add(new KillingSpree());
            Abilities.Add(new EviscerateAbility());
            Abilities.Add(new FanOfKnives());
            Abilities.Add(new FeintAbility());
            Abilities.Add(new GarotteAbility());
            Abilities.Add(new GougeAbility());
            Abilities.Add(new Hemorrhage());
            Abilities.Add(new InstantPoison());
            Abilities.Add(new KickAbility());
            Abilities.Add(new KidneyShotAbility());
            Abilities.Add(new KillingSpree());
            Abilities.Add(new LeechingPoison());
            Abilities.Add(new MarkedForDeathAbility());
            Abilities.Add(new Mutilate());
            Abilities.Add(new Premed());
            Abilities.Add(new RecupAbility());
            Abilities.Add(new RevealingStrikeAbility());
            Abilities.Add(new Rupture());
            Abilities.Add(new AoERupture());
            Abilities.Add(new RefreshRupture());
            Abilities.Add(new SapAbility());
            Abilities.Add(new ShadowReflection());
            Abilities.Add(new SinisterStrikeAbility());
            Abilities.Add(new SliceNDiceAbility());
            Abilities.Add(new ShadowDance());
            Abilities.Add(new StealthAbility());
            Abilities.Add(new VanishDefensive());
            Abilities.Add(new VanishOffensive());
            Abilities.Add(new Vendetta());
            Abilities.Add(new WoundPoison());
            Abilities.Add(new RacialHumanAbility());
            Abilities.Add(new RacialOrcBloodFuryAbility());
            Abilities.Add(new RacialsBloodElfAbility());
            Abilities.Add(new RacialsTrollBerserkingAbility());

           

        }
    }
}