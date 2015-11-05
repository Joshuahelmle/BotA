using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    class SliceNDiceAbility : AbilityBase
    {
        public SliceNDiceAbility() : base(WoWSpell.FromId(SpellBook.CastSliceNDice), true, false)
        {

            base.Category = AbilityCategory.Buff;
            
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(Target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            base.Conditions.Add(new ComboPointCondition(5));
            base.Conditions.Add(new ConditionOrList(
                new TargetNotAuraUpCondition(Me, Spell),
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(8), Spell, Me),
                new ConditionAndList(
                    new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(10.8), Spell, Me),
                    new TargetNotAuraUpCondition(target, WoWSpell.FromId(SpellBook.AuraFindWeakness)))));
            Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraVanish)));
            return await base.CastOnTarget(Target);
        }


    }
}