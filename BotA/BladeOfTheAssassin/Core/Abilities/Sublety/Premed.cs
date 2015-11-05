using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Sublety
{
    public class Premed : AbilityBase
    {
        public Premed()
            : base(WoWSpell.FromId(SpellBook.CastPremed), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new BooleanCondition(Me.ComboPoints <= 4));
            Conditions.Add(new ImStealthedCondition());
        }
    }
}