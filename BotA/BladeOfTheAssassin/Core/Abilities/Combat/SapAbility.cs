using System;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class SapAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(35);
        public SapAbility() : base(WoWSpell.FromId(SpellBook.CastSap), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.DrCategory = DrCategory.Incapacitate;
        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            InitializeBase();
            Conditions.Add(Energy);
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new TargetMaxRangeCondition(target, 10));
            Conditions.Add(new ImStealthedCondition());
            Conditions.Add(new TargetNotInCombatCondition(target));
            Conditions.Add(new ConditionSwitchTester(
                new TargetAuraUpCondition(target, Spell),
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(1), Spell, target )));
            return base.CastOnTarget(target);
        }
    }
}