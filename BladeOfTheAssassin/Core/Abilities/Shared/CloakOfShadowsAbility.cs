using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class CloakOfShadowsAbility : AbilityBase
    {
        public CloakOfShadowsAbility() 
            : base(WoWSpell.FromId(SpellBook.CastCloakOfShadows), false, true)
        {
            Category = AbilityCategory.Buff;

        }
    }
}