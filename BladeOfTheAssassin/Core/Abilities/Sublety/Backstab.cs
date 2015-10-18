using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Sublety
{
    public class Backstab : AbilityBase
    {
        ICondition Energy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(35);
        public Backstab()
            : base(WoWSpell.FromId(SpellBook.CastBackStab), true, false)
        {
            Category = AbilityCategory.Combat;
            
        }



        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(Energy);
            Conditions.Add(new BooleanCondition(Me.IsBehindOrSide(target)));
            Conditions.Add(new WillNotCapComboPointsCondition());
            Conditions.Add(new ImNotStealthedCondition());
            Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraVanish)));
            return await base.CastOnTarget(target);
        }
    }
}

