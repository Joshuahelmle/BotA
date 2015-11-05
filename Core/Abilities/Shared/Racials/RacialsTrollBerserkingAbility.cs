using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Shared.Racials
{
    class RacialsTrollBerserkingAbility :AbilityBase
    {
        public RacialsTrollBerserkingAbility() 
            : base(WoWSpell.FromId(SpellBook.RacialTrollBerserking),false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseTrollRacial));
            base.Conditions.Add(new IsRaceCondition(WoWRace.Troll));
            
           
        }
    }
}
