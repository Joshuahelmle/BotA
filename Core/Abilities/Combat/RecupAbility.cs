using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
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
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseRecup));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.RecupPercentage));
            Conditions.Add(new ComboPointCondition(3));
            Conditions.Add(new TargetNotAuraUpCondition(Me,Spell));
        }
    }
}