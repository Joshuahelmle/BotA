using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    class RevealingStrikeAbility : AbilityBase
    {
        private ICondition _energy;
        public RevealingStrikeAbility() : base(WoWSpell.FromId(SpellBook.CastRevealingStrike), true, false)
        {
            base.Category = AbilityCategory.Combat;
            _energy = new EnergyRangeCondition(25);
            base.Conditions.Add(_energy);
        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            base.Conditions.Add(_energy);
            base.Conditions.Add(new TargetNotAuraUpCondition(target, Spell));
            return base.CastOnTarget(target);
        }
    }
}
