using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class KidneyShotAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(25);
        public KidneyShotAbility() 
            : base(WoWSpell.FromId(SpellBook.CastKidneyShot), true, true)
        {
            Category = AbilityCategory.Combat;
            DrCategory = DrCategory.Stun;
        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            InitializeBase();
            Conditions.Add(Energy);
            Conditions.Add(new ComboPointCondition(5));
            Conditions.Add(new BooleanCondition(target != null && target.IsWithinMeleeRange));
            return base.CastOnTarget(target);
        }
    }
}