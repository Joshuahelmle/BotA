using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Shared.Racials
{
    class RacialHumanAbility : AbilityBase
    {
        public RacialHumanAbility() 
            : base(WoWSpell.FromId(SpellBook.RacialHumanEveryManForHimself), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseHumanRacial));
            base.Conditions.Add(new BooleanCondition(StyxWoW.Me.Race == WoWRace.Human));
            
        }
    }
}
