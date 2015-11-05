using System;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class WoundPoison : AbilityBase
    {
        public WoundPoison()
            : base(WoWSpell.FromId(SpellBook.CastWoundPoison), false, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.ApplyPoisons && !SettingsManager.Instance.UseDeadlyPoison));
            Conditions.Add(new ConditionOrList(
                 new TargetNotAuraUpCondition(Me, Spell),
                 new AuraMaxRemaningTimeCondition(TimeSpan.FromMinutes(5), Spell, Me)));
        }
    }
}