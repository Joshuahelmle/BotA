using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class FeintAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(20);
        public FeintAbility() 
            : base(WoWSpell.FromId(SpellBook.CastFeint), true, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(Energy);
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseFeint));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.FeintPercentage));
            Conditions.Add(new TargetNotAuraUpCondition(Me, Spell));
        }
    }
}