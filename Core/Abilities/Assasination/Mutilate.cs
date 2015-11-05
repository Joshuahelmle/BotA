using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Assasination
{
    public class Mutilate : AbilityBase
    {
        ICondition Energy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(55);
        public Mutilate()
            : base(WoWSpell.FromId(SpellBook.CastMutilate), true, false)
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
            Conditions.Add(new TargetIsInHealthRangeCondition(target, 35, 100));
            Conditions.Add(new WillNotCapComboPointsCondition(2));
            return await base.CastOnTarget(target);
        }

    }
}

