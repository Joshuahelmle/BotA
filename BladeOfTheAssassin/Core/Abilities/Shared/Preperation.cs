using System;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class Preperation : AbilityBase
    {
        public Preperation()
            : base(WoWSpell.FromId(SpellBook.CastPreperation), true, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new SpellIsOnCooldownCondition(SpellBook.CastVanish));

        }
    }
}