using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Conditions;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    class StealthAbility : AbilityBase
    {
        public StealthAbility() : base(WoWSpell.FromId(SpellBook.CastStealth), true, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraStealth)));
            base.Conditions.Add(new ImNotStealthedCondition());
        }
    }
}
