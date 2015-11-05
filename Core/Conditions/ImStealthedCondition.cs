using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class ImStealthedCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.AuraExists(SpellBook.AuraStealth) || StyxWoW.Me.AuraExists(SpellBook.AuraSubterfuge) || StyxWoW.Me.AuraExists(SpellBook.AuraShadowDance) || StyxWoW.Me.AuraExists(SpellBook.AuraVanish);
        }
    }
}