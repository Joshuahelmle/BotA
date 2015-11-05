using System;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Conditions.Auras;
using System.Threading.Tasks;
using Styx.WoWInternals.WoWObjects;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class ShadowReflection : AbilityBase
    {
        public ShadowReflection()
            : base(WoWSpell.FromId(SpellBook.CastShadowReflection), false, true)
        {
            Category = AbilityCategory.Buff;
            
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseShadowReflection));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(new ConditionSwitchTester(
            new BooleanCondition(Me.Specialization == Styx.WoWSpec.RogueSubtlety),
            new ConditionAndList(
                new CoolDownLeftMaxCondition(WoWSpell.FromId(SpellBook.AuraShadowDance), System.TimeSpan.FromSeconds(1)),
                new TargetAuraUpCondition(Me,WoWSpell.FromId(SpellBook.CastSliceNDice))), // <-- If in Subtlety Specc
            new ConditionSwitchTester(
                new BooleanCondition(Me.Specialization == Styx.WoWSpec.RogueAssassination),
                new TargetAuraUpCondition(target, WoWSpell.FromId(SpellBook.CastRupture)) // <-- If in AssaSpecc
                ) // Add Combat here
               ));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.ShadowReflectionOnlyOnBoss),
                new OnlyOnBossCondition()));
            return await base.CastOnTarget(target);
        }

    }
}