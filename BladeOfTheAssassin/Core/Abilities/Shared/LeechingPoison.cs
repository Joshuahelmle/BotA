using System;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class LeechingPoison : AbilityBase
    {
        public LeechingPoison()
            : base(WoWSpell.FromId(SpellBook.CastLeechingPoison), false, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.ApplyPoisons && !SettingsManager.Instance.UseCripplingPoison));
            Conditions.Add(new ConditionOrList(
                 new TargetNotAuraUpCondition(Me, Spell),
                 new AuraMaxRemaningTimeCondition(TimeSpan.FromMinutes(5), Spell, Me)));
        }
    }
}