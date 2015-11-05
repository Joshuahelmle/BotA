using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Shared.Racials
{
    class RacialsBloodElfAbility : AbilityBase
    {
        public RacialsBloodElfAbility()
            : base(WoWSpell.FromId(SpellBook.RacialBloodElfArcaneTorrent), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseBloodElfRacial));
            base.Conditions.Add(new IsRaceCondition(WoWRace.BloodElf));
           
           
                
        }
    }
}
