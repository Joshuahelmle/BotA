using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class RefreshRupture : AbilityBase
    {
        private ICondition _energy;
        public RefreshRupture()
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
            Conditions.Add(new ComboPointCondition(5));
            return await base.CastOnTarget(target);
        }

    }
}