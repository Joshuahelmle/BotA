using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BladeOfTheAssassin.Core.Abilities;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using BladeOfTheAssassin.Core.Utilities;

namespace BladeOfTheAssassin.Core.Managers
{
    public class DiminishingReturnManager
    {
        #region [BotA] Singletons

        private static DiminishingReturnManager _singletonInstance;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static DiminishingReturnManager Instance
        {
            get
            {
                return _singletonInstance ?? (_singletonInstance = new DiminishingReturnManager());
            }
        }

        public DiminishingReturnManager()
        {
            DisorientedTargets = new Dictionary<WoWUnit, Stopwatch>();
            DisorientedTargetsLevel = new Dictionary<WoWUnit, int>();
            StunnedTargets = new Dictionary<WoWUnit, Stopwatch>();
            StunnedTargetsLevel = new Dictionary<WoWUnit, int>();
            RootedTargets = new Dictionary<WoWUnit, Stopwatch>();
            RootedTargetsLevel = new Dictionary<WoWUnit, int>();
            IncapacitatedTargets = new Dictionary<WoWUnit, Stopwatch>();
            IncapacitatedTargetsLevel = new Dictionary<WoWUnit, int>();
            SilenceTargets = new Dictionary<WoWUnit, Stopwatch>();
            SilenceTargetsLevel = new Dictionary<WoWUnit, int>();
            DeleteDisorientedTargets = new List<WoWUnit>();
            DeleteIncapacitatedTargets = new List<WoWUnit>();
            DeleteRootedTargets = new List<WoWUnit>();
            DeleteSilencedTargets = new List<WoWUnit>();
            DeleteStunnedTargets = new List<WoWUnit>();

            _stunSpells = new List<WoWSpell>
            {
                WoWSpell.FromId(SpellBook.CastAsphyxiate),
                WoWSpell.FromId(SpellBook.AuraGnaw),
                WoWSpell.FromId(SpellBook.AuraMonstrousBlow),
                WoWSpell.FromId(SpellBook.AuraRemorselessWinter),
                WoWSpell.FromId(SpellBook.CastMaim),
                WoWSpell.FromId(SpellBook.CastMightyBash),
                WoWSpell.FromId(SpellBook.AuraBindingShot),
                WoWSpell.FromId(SpellBook.AuraIntimidation),
                WoWSpell.FromId(SpellBook.SpellDeepfreeze),
                WoWSpell.FromId(SpellBook.AuraChargingOxeWave),
                WoWSpell.FromId(SpellBook.AuraFistsOfFury),
                WoWSpell.FromId(SpellBook.AuraLegSweep),
                WoWSpell.FromId(SpellBook.CastHammerOfJustice),
                WoWSpell.FromId(SpellBook.CastHolyWrath),
                WoWSpell.FromId(SpellBook.CastFistOfJustice),
                WoWSpell.FromId(SpellBook.CastCheapShot),
                WoWSpell.FromId(SpellBook.CastKidneyShot),
                WoWSpell.FromId(SpellBook.CastPulverize),
                WoWSpell.FromId(SpellBook.AuraStaticCharge),
                WoWSpell.FromId(SpellBook.AuraEarthquake),
                WoWSpell.FromId(SpellBook.CastAxeToss),
                WoWSpell.FromId(SpellBook.CastShadowFury),
                WoWSpell.FromId(SpellBook.AuraInfernalAwaking),
                WoWSpell.FromId(SpellBook.AuraShockWave),
                WoWSpell.FromId(SpellBook.AuraStormBolt),
                WoWSpell.FromId(SpellBook.AuraDragonRoar),
                WoWSpell.FromId(SpellBook.RacialTauren)
            };
            _rootsSpells = new List<WoWSpell>
            {
              WoWSpell.FromId(SpellBook.AuraChainsOfIce),
              WoWSpell.FromId(SpellBook.CastEntanglingRoots),
              WoWSpell.FromId(SpellBook.AuraTreantEntanglingRoots),
              WoWSpell.FromId(SpellBook.CastMassEntanglement),
              WoWSpell.FromId(SpellBook.AuraPetCharge),
              WoWSpell.FromId(SpellBook.AuraNarrowEscape),
              WoWSpell.FromId(SpellBook.AuraEntrapment),
              WoWSpell.FromId(SpellBook.CastFrostNova),
              WoWSpell.FromId(SpellBook.CastFreeze),
              WoWSpell.FromId(SpellBook.AuraIceWard),
              WoWSpell.FromId(SpellBook.AuraDisable),
              WoWSpell.FromId(SpellBook.AuraGlyphOfMindBlast),
              WoWSpell.FromId(SpellBook.AuraVoidTendrils),
              WoWSpell.FromId(SpellBook.AuraFrozenPower),
              WoWSpell.FromId(SpellBook.AuraEarthGrab),
            };

            _disorientationSpells = new List<WoWSpell>
            {
                WoWSpell.FromId(SpellBook.CastCyclone),
                WoWSpell.FromId(SpellBook.CastTurnEvil),
                WoWSpell.FromId(SpellBook.CastTurnEvilTalented),
                WoWSpell.FromId(SpellBook.CastBlind),
                WoWSpell.FromId(SpellBook.CastPsychicScream),
                WoWSpell.FromId(SpellBook.AuraFear),
                WoWSpell.FromId(SpellBook.AuraGlyphOfFear),
                WoWSpell.FromId(SpellBook.CastHowlOfTerror),
                WoWSpell.FromId(SpellBook.CastMesmerize),
                WoWSpell.FromId(SpellBook.CastSeduction),
                WoWSpell.FromId(SpellBook.CastIntimidatingShout),
                WoWSpell.FromId(SpellBook.AuraChainsOfIce),
            };

            _incapacitatesSpells = new List<WoWSpell>
            {
                WoWSpell.FromId(SpellBook.CastIncapacitatingRoar),
                WoWSpell.FromId(SpellBook.AuraFreezingTrap),
                WoWSpell.FromId(SpellBook.CastWyvernSting),
                WoWSpell.FromId(SpellBook.CastPolySheep),
                WoWSpell.FromId(SpellBook.CastPolyTurtle),
                WoWSpell.FromId(SpellBook.CastPolyPig),
                WoWSpell.FromId(SpellBook.CastPolyBlackCat),
                WoWSpell.FromId(SpellBook.CastPolyRabbit),
                WoWSpell.FromId(SpellBook.CastPolyTurkey),
                WoWSpell.FromId(SpellBook.AuraRingOfFrost),
                WoWSpell.FromId(SpellBook.CastDragonsBreath),
                WoWSpell.FromId(SpellBook.CastParalysis),
                WoWSpell.FromId(SpellBook.AuraRingOfPeace),
                WoWSpell.FromId(SpellBook.CastRepentance),
                WoWSpell.FromId(SpellBook.CastShackleUndead),
                WoWSpell.FromId(SpellBook.CastPsychichHorror),
                WoWSpell.FromId(SpellBook.CastHolyWordChastise),
                WoWSpell.FromId(SpellBook.CastDominateMind),
                WoWSpell.FromId(SpellBook.CastGouge),
                WoWSpell.FromId(SpellBook.CastSap),
                WoWSpell.FromId(SpellBook.CastHex),
                WoWSpell.FromId(SpellBook.AuraBloodHorror),
                WoWSpell.FromId(SpellBook.CastMortalCoil),
                WoWSpell.FromId(SpellBook.RacialPandarenQuakingPalm)
            };

            _silenceSpells = new List<WoWSpell>
            {
                WoWSpell.FromId(SpellBook.CastStrangulate),
                WoWSpell.FromId(SpellBook.AuraFeaSilence),
                WoWSpell.FromId(SpellBook.AuraSolarBeam),
                WoWSpell.FromId(SpellBook.CastFrostJaw),
                WoWSpell.FromId(SpellBook.CastAvengersShield),
                WoWSpell.FromId(SpellBook.CastSilence),
                WoWSpell.FromId(SpellBook.AuraGarotteSilence),
                WoWSpell.FromId(SpellBook.CastBloodElfRogue),
                WoWSpell.FromId(SpellBook.CastBloodElfClothClass),
                WoWSpell.FromId(SpellBook.CastBloodElfDK),
                WoWSpell.FromId(SpellBook.CastBloodElfWarrior),
                WoWSpell.FromId(SpellBook.CastBloodElfHunter),
                WoWSpell.FromId(SpellBook.CastBloodElfMonk),
                WoWSpell.FromId(SpellBook.CastBloodElfPaladin),
            };

            updateTimer = new Stopwatch();

        }

        public void Init()
        {
            AttachGetDrFromCombatLog();
            updateTimer.Start();
            
        }

#endregion
        /// <summary>
        /// Lists of the Spells which share the same DR
        /// </summary>
        private List<WoWSpell> _disorientationSpells;
        private List<WoWSpell> _stunSpells;
        private List<WoWSpell> _rootsSpells;
        private List<WoWSpell> _incapacitatesSpells;
        private List<WoWSpell> _silenceSpells; 

        /// <summary>
        /// A Dictionary of units currently disorient dr'ed, with the level of the DR
        /// </summary>
        public Dictionary<WoWUnit,int> DisorientedTargetsLevel;
        /// <summary>
        /// A Dictionary which holds the units on Desorientated DR 
        /// </summary>
        public Dictionary<WoWUnit,Stopwatch> DisorientedTargets;
        /// <summary>
        /// A Dictionary of units currently stun dr'ed, with the level of the DR
        /// </summary>
        public Dictionary<WoWUnit, int> StunnedTargetsLevel;
        /// <summary>
        /// A Dictionary which holds the units on Stun DR 
        /// </summary>
        public Dictionary<WoWUnit, Stopwatch> StunnedTargets;
        /// <summary>
        /// A Dictionary of units currently root dr'ed, with the level of the DR
        /// </summary>
        public Dictionary<WoWUnit, int> RootedTargetsLevel;
        /// <summary>
        /// A Dictionary which holds the units on root DR 
        /// </summary>
        public Dictionary<WoWUnit, Stopwatch> RootedTargets;
        /// <summary>
        /// A Dictionary of units currently incapacitate dr'ed, with the level of the DR
        /// </summary>
        public Dictionary<WoWUnit, int> IncapacitatedTargetsLevel;
        /// <summary>
        /// A Dictionary which holds the units on incapacitate DR 
        /// </summary>
        public Dictionary<WoWUnit, Stopwatch> IncapacitatedTargets;
        /// <summary>
        /// A Dictionary of units currently silence dr'ed, with the level of the DR
        /// </summary>
        public Dictionary<WoWUnit, int> SilenceTargetsLevel;
        /// <summary>
        /// A Dictionary which holds the units on silence DR 
        /// </summary>
        public Dictionary<WoWUnit, Stopwatch> SilenceTargets;

        /// <summary>
        /// Some Helper lists, to actually delete from the Dictionarys, since we can't delete them in a for each loop, because that messes up the iterator.
        /// </summary>
        public List<WoWUnit> DeleteStunnedTargets;
        public List<WoWUnit> DeleteRootedTargets;
        public List<WoWUnit> DeleteIncapacitatedTargets;
        public List<WoWUnit> DeleteSilencedTargets;
        public List<WoWUnit> DeleteDisorientedTargets; 

        public Stopwatch updateTimer;
        
        /// <summary>
        /// Updates the Lists, this should only be called during main pulse
        /// </summary>
        public void Update()
        {
            if(Main.Debug)Log.Diagnostics("In DiminishingReturnManager.Update()");
            if (updateTimer.ElapsedMilliseconds >= 1500)
            {
                RemoveDr();
                updateTimer.Restart();
            }
        }

        private void AddDr(WoWUnit target, DrCategory category)
        {
            if (target == null || !target.IsValid)
                return;

            switch (category)
            {
                case DrCategory.Disoriented:
                    if (!Instance.DisorientedTargets.ContainsKey(target))
                        Instance.DisorientedTargets.Add(target, Stopwatch.StartNew());
                    else
                    {
                        Instance.DisorientedTargets.Remove(target);
                        Instance.DisorientedTargets.Add(target, Stopwatch.StartNew());
                    }

                    if (!Instance.DisorientedTargetsLevel.ContainsKey(target))
                        Instance.DisorientedTargetsLevel.Add(target, 1);
                    else
                    {
                        var oldDrLevel = Instance.DisorientedTargetsLevel[target];
                        Instance.DisorientedTargetsLevel.Remove(target);
                        Instance.DisorientedTargetsLevel.Add(target, oldDrLevel + 1);
                    }

                    Log.Combat(String.Format("Added {0} on Desorientation DR, Level : {1}",
                        target.SafeName,
                        Instance.DisorientedTargetsLevel[target]));
                    break;
                case DrCategory.Stun:
                    if (!Instance.StunnedTargets.ContainsKey(target))
                        Instance.StunnedTargets.Add(target, Stopwatch.StartNew());
                    else
                    {
                        Instance.StunnedTargets.Remove(target);
                        Instance.StunnedTargets.Add(target, Stopwatch.StartNew());
                    }
                    if (!Instance.StunnedTargetsLevel.ContainsKey(target))
                        Instance.StunnedTargetsLevel.Add(target, 1);
                    else
                    {
                        var oldDrLevel = Instance.StunnedTargetsLevel[target];
                        Instance.StunnedTargetsLevel.Remove(target);
                        Instance.StunnedTargetsLevel.Add(target, oldDrLevel + 1);
                    }

                    Log.Combat(String.Format("Added {0} on Stun DR, Level : {1}",
                        target.SafeName,
                        Instance.StunnedTargetsLevel[target]));
                    break;
                 case DrCategory.Root:
                    if (!Instance.RootedTargets.ContainsKey(target))
                        Instance.RootedTargets.Add(target, Stopwatch.StartNew());
                    else
                    {
                        Instance.RootedTargets.Remove(target);
                        Instance.RootedTargets.Add(target, Stopwatch.StartNew());
                    }
                    if (!Instance.RootedTargetsLevel.ContainsKey(target))
                        Instance.RootedTargetsLevel.Add(target, 1);
                    else
                    {
                        var oldDrLevel = Instance.RootedTargetsLevel[target];
                        Instance.RootedTargetsLevel.Remove(target);
                        Instance.RootedTargetsLevel.Add(target, oldDrLevel + 1);
                    }

                    Log.Combat(String.Format("Added {0} on Root DR, Level : {1}",
                        target.SafeName,
                        Instance.RootedTargetsLevel[target]));
                    break;
                case DrCategory.Incapacitate:
                     if (!Instance.IncapacitatedTargets.ContainsKey(target))
                        Instance.IncapacitatedTargets.Add(target, Stopwatch.StartNew());
                    else
                    {
                        Instance.IncapacitatedTargets.Remove(target);
                        Instance.IncapacitatedTargets.Add(target, Stopwatch.StartNew());
                    }
                    if (!Instance.IncapacitatedTargetsLevel.ContainsKey(target))
                        Instance.IncapacitatedTargetsLevel.Add(target, 1);
                    else
                    {
                        var oldDrLevel = Instance.IncapacitatedTargetsLevel[target];
                        Instance.IncapacitatedTargetsLevel.Remove(target);
                        Instance.IncapacitatedTargetsLevel.Add(target, oldDrLevel + 1);
                    }

                    Log.Combat(String.Format("Added {0} on Incapacitate DR, Level : {1}",
                        target.SafeName,
                        Instance.IncapacitatedTargetsLevel[target]));
                    break;
                case DrCategory.Silence:
                     if (!Instance.SilenceTargets.ContainsKey(target))
                        Instance.SilenceTargets.Add(target, Stopwatch.StartNew());
                    else
                    {
                        Instance.SilenceTargets.Remove(target);
                        Instance.SilenceTargets.Add(target, Stopwatch.StartNew());
                    }
                    if (!Instance.SilenceTargetsLevel.ContainsKey(target))
                        Instance.SilenceTargetsLevel.Add(target, 1);
                    else
                    {
                        var oldDrLevel = Instance.SilenceTargetsLevel[target];
                        Instance.SilenceTargetsLevel.Remove(target);
                        Instance.SilenceTargetsLevel.Add(target, oldDrLevel + 1);
                    }

                    Log.Combat(String.Format("Added {0} on Silence DR, Level : {1}",
                        target.SafeName,
                        Instance.SilenceTargetsLevel[target]));
                    break;
            }
        }


    

        private void RemoveDr()
        {
            foreach (var unit in Instance.DisorientedTargets)
            {
                if (unit.Key == null || !unit.Key.IsValid)
                    return;
                if (!Instance.DisorientedTargets.ContainsKey(unit.Key))
                    return;
                if (unit.Key.IsDead || Instance.DisorientedTargets[unit.Key].ElapsedMilliseconds > 18000) 
                    DeleteDisorientedTargets.Add(unit.Key);            
            }
            foreach (var unit in DeleteDisorientedTargets)
            {

                Instance.DisorientedTargets.Remove(unit);
                if (!Instance.DisorientedTargetsLevel.ContainsKey(unit))
                    return;
                Instance.DisorientedTargetsLevel.Remove(unit);
                Log.Combat(String.Format("Removed {0} from Desorientation DR",
                    unit.SafeName
                    ));


            }
            DeleteDisorientedTargets.Clear();



            foreach (var unit in Instance.StunnedTargets)
            {
                if (unit.Key == null || !unit.Key.IsValid)
                    return;
                if (!Instance.StunnedTargets.ContainsKey(unit.Key))
                    return;
                if (unit.Key.IsDead || Instance.StunnedTargets[unit.Key].ElapsedMilliseconds > 18000)
                        DeleteStunnedTargets.Add(unit.Key);

            }

            foreach (var unit in DeleteStunnedTargets)
            {
                        Instance.StunnedTargets.Remove(unit);
                        if (!Instance.StunnedTargetsLevel.ContainsKey(unit))
                            return;
                            Instance.StunnedTargetsLevel.Remove(unit);
                        Log.Combat(String.Format("Removed {0} from Stun DR",
                       unit.SafeName
                       ));
             }
             DeleteStunnedTargets.Clear();

            foreach (var unit in Instance.RootedTargets)
            {
                if (unit.Key == null || !unit.Key.IsValid)
                    return;
                if (!Instance.RootedTargets.ContainsKey(unit.Key))
                    return;
                if (unit.Key.IsDead || Instance.RootedTargets[unit.Key].ElapsedMilliseconds > 18000)
                    DeleteRootedTargets.Add(unit.Key);
            }
            foreach (var unit in DeleteRootedTargets)
            {
              Instance.RootedTargets.Remove(unit);
                        if (!Instance.RootedTargetsLevel.ContainsKey(unit))
                            return;
                       Instance.RootedTargetsLevel.Remove(unit);
                        Log.Combat(String.Format("Removed {0} from Rooted DR",
                       unit.SafeName
                       ));
             }
             DeleteRootedTargets.Clear(); 
              
            foreach (var unit in Instance.IncapacitatedTargets)
            {
                if (unit.Key == null || !unit.Key.IsValid)
                    return;

                if (!Instance.IncapacitatedTargets.ContainsKey(unit.Key))
                    return;
                if (unit.Key.IsDead || Instance.IncapacitatedTargets[unit.Key].ElapsedMilliseconds > 18000)
                        DeleteIncapacitatedTargets.Add(unit.Key);
                }
                foreach (var unit in DeleteIncapacitatedTargets)
                    {
                        Instance.IncapacitatedTargets.Remove(unit);
                            if (!Instance.IncapacitatedTargetsLevel.ContainsKey(unit))
                                return;
                           Instance.IncapacitatedTargetsLevel.Remove(unit);
                            Log.Combat(String.Format("Removed {0} From Incapacitation DR",
                           unit.SafeName
                           ));
                     }
                     DeleteIncapacitatedTargets.Clear();

            foreach (var unit in Instance.SilenceTargets)
            {
                if (unit.Key == null || !unit.Key.IsValid)
                    return;

                if (!Instance.SilenceTargets.ContainsKey(unit.Key))
                    return;
                if (unit.Key.IsDead || Instance.SilenceTargets[unit.Key].ElapsedMilliseconds > 18000)
                    DeleteSilencedTargets.Add(unit.Key);
            }
            foreach (var unit in DeleteSilencedTargets)
            {
                Instance.SilenceTargets.Remove(unit);
                if (!Instance.SilenceTargetsLevel.ContainsKey(unit))
               Instance.SilenceTargetsLevel.Remove(unit);
                Log.Combat(String.Format("Removed {0} on Silence DR",
               unit.SafeName
               )); 
            }
            DeleteSilencedTargets.Clear();
           }

        /// <summary>
        /// returns the DR level of the given target in given DR Category.
        /// </summary>
        public int GetDrLevel(WoWUnit target, DrCategory category )
        {
            if (target == null || !target.IsValid)
                return 0;
            var level = 0;
            switch (category)
            {
                case DrCategory.Disoriented:
                    level = DisorientedTargetsLevel.ContainsKey(target) ? DisorientedTargetsLevel[target] : 0;
                    break;
                case DrCategory.Stun:
                    level = StunnedTargetsLevel.ContainsKey(target) ? StunnedTargetsLevel[target] : 0;
                    break;
                case DrCategory.Root:
                    level = RootedTargetsLevel.ContainsKey(target) ? RootedTargetsLevel[target] : 0;
                    break;
                case DrCategory.Incapacitate:
                    level = IncapacitatedTargetsLevel.ContainsKey(target) ? IncapacitatedTargetsLevel[target] : 0;
                    break;
                case DrCategory.Silence:
                    level = SilenceTargetsLevel.ContainsKey(target) ? SilenceTargetsLevel[target] : 0;
                    break;
            }
            return level;
        }

        private static void GetDrFromCombatLog(object sender, LuaEventArgs args)
        {
            var clog = new CombatLogEventArgs(args.EventName, args.FireTimeStamp, args.Args);

            if ((clog.Event != null && (clog.Event.Equals("SPELL_AURA_REFRESH") || clog.Event.Equals("SPELL_AURA_APPLIED"))) &&
                clog.DestUnit != null && !clog.DestUnit.IsFriendly &&
                (Instance._disorientationSpells.Contains(clog.Spell) ||
                Instance._stunSpells.Contains(clog.Spell) ||
                Instance._rootsSpells.Contains(clog.Spell) ||
                Instance._incapacitatesSpells.Contains(clog.Spell) ||
                Instance._silenceSpells.Contains(clog.Spell)))
            {
                if (Instance._disorientationSpells.Contains(clog.Spell)) { 
                    Instance.AddDr(clog.DestUnit, DrCategory.Disoriented);
                    return;
                }
                if (Instance._stunSpells.Contains(clog.Spell))
                {
                    Instance.AddDr(clog.DestUnit, DrCategory.Stun);
                    return;
                }
                if (Instance._rootsSpells.Contains(clog.Spell))
                {
                    Instance.AddDr(clog.DestUnit, DrCategory.Root);
                    return;
                }
                if (Instance._incapacitatesSpells.Contains(clog.Spell))
                {
                    Instance.AddDr(clog.DestUnit, DrCategory.Incapacitate);
                    return;
                }
                if (Instance._silenceSpells.Contains(clog.Spell))
                {
                    Instance.AddDr(clog.DestUnit, DrCategory.Silence);
                    return;
                }
                }

        }



        private static bool _combatLogAttached;

        private static void AttachGetDrFromCombatLog()
        {
            if (_combatLogAttached)
                return;

            Lua.Events.AttachEvent("COMBAT_LOG_EVENT_UNFILTERED", GetDrFromCombatLog);
            Log.Diagnostics("Attached GetDRFromCombatLog");

            _combatLogAttached = true;
        }

       
       

       

        

    }
}

/// <summary>
/// The CombatLog class provided by Singular
/// </summary>
    internal class CombatLogEventArgs : LuaEventArgs
    {
        public CombatLogEventArgs(string eventName, uint fireTimeStamp, object[] args)
            : base(eventName, fireTimeStamp, args)
        {
        }

        public double Timestamp { get { return (double)Args[0]; } }

        public string Event { get { return Args[1].ToString(); } }

        // Is this a string? bool? what? What the hell is it even used for?
        // it's a boolean, and it doesn't look like it has any real impact codewise apart from maybe to break old addons? - exemplar 4.1
        public string HideCaster { get { return Args[2].ToString(); } }

        public WoWGuid SourceGuid { get { return ArgToGuid(Args[3]); } }

        public WoWUnit SourceUnit
        {
            get
            {
                WoWGuid cachedSourceGuid = SourceGuid;
                return
                    ObjectManager.GetObjectsOfType<WoWUnit>(true, true).FirstOrDefault(
                        o => o.IsValid && (o.Guid == cachedSourceGuid || o.DescriptorGuid == cachedSourceGuid));
            }
        }

        public string SourceName { get { return Args[4].ToString(); } }

        public int SourceFlags { get { return (int)(double)Args[5]; } }

        public WoWGuid DestGuid { get { return ArgToGuid(Args[7]); } }

        public WoWUnit DestUnit
        {
            get
            {
                WoWGuid cachedDestGuid = DestGuid;
                return
                    ObjectManager.GetObjectsOfType<WoWUnit>(true, true).FirstOrDefault(
                        o => o.IsValid && (o.Guid == cachedDestGuid || o.DescriptorGuid == cachedDestGuid));
            }
        }

        public string DestName { get { return Args[8].ToString(); } }

        public int DestFlags { get { return (int)(double)Args[9]; } }

        public int SpellId { get { return (int)(double)Args[11]; } }

        public WoWSpell Spell { get { return WoWSpell.FromId(SpellId); } }

        public string SpellName { get { return Args[12].ToString(); } }

        public WoWSpellSchool SpellSchool { get { return (WoWSpellSchool)(int)(double)Args[13]; } }

        public object[] SuffixParams
        {
            get
            {
                var args = new List<object>();
                for (int i = 11; i < Args.Length; i++)
                {
                    if (Args[i] != null)
                    {
                        args.Add(args[i]);
                    }
                }
                return args.ToArray();
            }
        }

        private static WoWGuid ArgToGuid(object o)
        {
	        string s = o.ToString();
	        WoWGuid guid;
	        if (!WoWGuid.TryParseFriendly(s, out guid))
		        guid = WoWGuid.Empty;

	        return guid;
        }
    }
