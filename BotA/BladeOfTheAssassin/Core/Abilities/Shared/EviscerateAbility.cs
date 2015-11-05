using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class EviscerateAbility : AbilityBase
    {
        private ICondition _energy;
        public EviscerateAbility() : base(WoWSpell.FromId(SpellBook.CastEviscerate), true, false)
        {
            Category = AbilityCategory.Combat;
            _energy = new EnergyRangeCondition(35);
           
            
        }



         public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(_energy);
            Conditions.Add(new ComboPointCondition(5));
           // Conditions.Add(new SpellIsOnCooldownCondition(SpellBook.CastDeathFromAbove));
            Conditions.Add(new ConditionSwitchTester(new BooleanCondition(Me.Specialization == Styx.WoWSpec.RogueSubtlety),
                new ConditionOrList(
                new TargetAuraUpCondition(target, WoWSpell.FromId(SpellBook.AuraFindWeakness)),
                new ConditionAndList(
                    new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraAnticipation), 3),
                    new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraAnticipation)))),
                    new BooleanCondition(true)));
            return await base.CastOnTarget(target);
        }
    

    }
}

