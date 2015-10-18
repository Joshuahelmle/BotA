using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class VanishDefensive : AbilityBase
    {
        public VanishDefensive() 
            : base(WoWSpell.FromId(SpellBook.CastVanish), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, 20));
        }
    }
}