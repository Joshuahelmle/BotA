using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class KickAbility : AbilityBase
    {
        public KickAbility() 
            : base(WoWSpell.FromId(SpellBook.CastKick), false, true)
        {
            Category = AbilityCategory.Combat;

        }
    }
}