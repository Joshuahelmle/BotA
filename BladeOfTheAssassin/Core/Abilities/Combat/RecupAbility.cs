using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities
{
    public class RecupAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(30);
        public RecupAbility() 
            : base(WoWSpell.FromId(SpellBook.CastRecuperate), true, false)
        {
            Category = AbilityCategory.Heal;
            Conditions.Add(Energy);
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, 60));
            Conditions.Add(new ComboPointCondition(3));
            Conditions.Add(new TargetNotAuraUpCondition(Me,Spell));
        }
    }
}