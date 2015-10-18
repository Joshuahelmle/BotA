using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class SinisterStrikeAbility : AbilityBase
    {
        public SinisterStrikeAbility() : base(WoWSpell.FromId(SpellBook.CastSinisterStrike), true, false)
        {
            base.Category = AbilityCategory.Combat;

            var energy = new EnergyRangeCondition(50);
            base.Conditions.Add(new TargetNotAuraUpCondition(StyxWoW.Me , WoWSpell.FromId(SpellBook.AuraStealth)));
            base.Conditions.Add(energy);

        }
    }
}