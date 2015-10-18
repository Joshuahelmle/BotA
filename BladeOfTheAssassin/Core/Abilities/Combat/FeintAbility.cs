using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
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
            Conditions.Add(new TargetNotAuraUpCondition(Me, Spell));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, 40));
        }
    }
}