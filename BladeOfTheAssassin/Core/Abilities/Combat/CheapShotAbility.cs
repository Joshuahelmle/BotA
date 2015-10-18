using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class CheapShotAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(40);
        public CheapShotAbility() 
            : base(WoWSpell.FromId(SpellBook.CastCheapShot), true, false)
        {
            Category = AbilityCategory.Combat;
            DrCategory = DrCategory.Stun;

        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            Conditions.Add(Energy);
            Conditions.Add(new ImStealthedCondition());
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            base.Conditions.Add(new TargetNotAuraUpCondition(target, Spell, false));
            return base.CastOnTarget(target);
        }
    }
}