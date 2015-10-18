using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class DeathFromAboveAbility : AbilityBase
    {
        private ICondition _energy;
        public DeathFromAboveAbility() : base(WoWSpell.FromId(SpellBook.CastDeathFromAbove), true, true)
        {
            Category = AbilityCategory.Combat;
            _energy =  new EnergyRangeCondition(50);
            base.Conditions.Add(_energy);
            base.Conditions.Add(new ComboPointCondition(5));

        }
    }
}