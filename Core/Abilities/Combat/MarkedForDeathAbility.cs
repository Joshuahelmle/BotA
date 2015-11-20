using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class MarkedForDeathAbility : AbilityBase
    {
        public MarkedForDeathAbility() 
            : base(WoWSpell.FromId(SpellBook.CastMarkedForDeath), true, true)
        {
            Category = AbilityCategory.Combat;
            
        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            InitializeBase();
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(Me.ComboPoints <= 2));
            return base.CastOnTarget(target);
        }
    }
}