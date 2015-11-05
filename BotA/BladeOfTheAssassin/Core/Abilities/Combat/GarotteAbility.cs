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
    class GarotteAbility : AbilityBase
    {
        private ICondition _energy;
        public GarotteAbility() : base(WoWSpell.FromId(SpellBook.CastGarotte), true, false)
        {
            Category = AbilityCategory.Combat;
            _energy = new EnergyRangeCondition(45);
            
        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            base.Conditions.Add(_energy);
            Conditions.Add(new BooleanCondition(target != null));
            base.Conditions.Add(new ImStealthedCondition());
            base.Conditions.Add(new TargetNotAuraUpCondition(target, Spell));
            return base.CastOnTarget(target);
        }
    }
}
