using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class AoERupture : AbilityBase
    {
        private ICondition _energy;
        public AoERupture()
            : base(WoWSpell.FromId(SpellBook.CastRupture), true, false)
        {
            Category = AbilityCategory.Combat;
            _energy = new EnergyRangeCondition(25);

        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(_energy);
            Conditions.Add(new ComboPointCondition(3));
            Conditions.Add(new ConditionOrList(
                new TargetNotAuraUpCondition(target, Spell),
                new AuraMaxRemaningTimeCondition(System.TimeSpan.FromSeconds(7.2), Spell, target)));
            return await base.CastOnTarget(target);
        }

    }
}