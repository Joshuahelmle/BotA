using System;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class CripplingPoison : AbilityBase
    {
        public CripplingPoison() 
            : base(WoWSpell.FromId(SpellBook.CastCripplingPoison), false, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.ApplyPoisons));
            Conditions.Add(new ConditionOrList(
                 new TargetNotAuraUpCondition(Me, Spell),
                 new AuraMaxRemaningTimeCondition(TimeSpan.FromMinutes(5), Spell, Me)));
        }
    }
}