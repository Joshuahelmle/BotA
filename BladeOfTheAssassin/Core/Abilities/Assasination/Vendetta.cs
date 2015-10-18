using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Assasination
{
    public class Vendetta : AbilityBase
    {
        public Vendetta()
            : base(WoWSpell.FromId(SpellBook.CastVendetta), true, true)
        {
            Category = AbilityCategory.Buff;
        }


        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(new TargetAuraUpCondition(target, WoWSpell.FromId(SpellBook.CastRupture)));
            return await base.CastOnTarget(target);
        }

    }
}

