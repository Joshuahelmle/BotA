using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class GougeAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(45);
        public GougeAbility()
            : base(WoWSpell.FromId(SpellBook.CastGouge), true, true)
        {
            Category = AbilityCategory.Combat;
            DrCategory = DrCategory.Incapacitate;

        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            Conditions.Add(Energy);
            Conditions.Add(new BooleanCondition(target != null && target.IsWithinMeleeRange));
            return base.CastOnTarget(target);
        }
    }
}