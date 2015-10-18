using System;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class VanishOffensive : AbilityBase
    {
        public VanishOffensive() 
            : base(WoWSpell.FromId(SpellBook.CastVanish), false , true)
        {
            Category = AbilityCategory.Buff;
           
               
        }


        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(new BooleanCondition(Me.AuraStacks(SpellBook.AuraAnticipation) <= 1));
           //  t18 bonus! add if you got t18
            Conditions.Add(new ConditionOrList(
                new CoolDownLeftMaxCondition(WoWSpell.FromId(SpellBook.AuraShadowDance), System.TimeSpan.FromSeconds(1)),
                new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.AuraShadowDance), System.TimeSpan.FromSeconds(7))));
            Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraDeathlyShadows)));
            /*
            Conditions.Add(new ImNotStealthedCondition());
            Conditions.Add(new TargetNotAuraUpCondition(target, WoWSpell.FromId(SpellBook.AuraFindWeakness))); */
            return await base.CastOnTarget(target);
        }
    }
}