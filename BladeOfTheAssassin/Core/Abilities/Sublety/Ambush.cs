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
    public class Ambush : AbilityBase
        
    {
         ICondition Energy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(60);
         ICondition SDEnergy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(40);
        public Ambush()
            : base(WoWSpell.FromId(SpellBook.CastAmbush), true, false)
       
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(SDEnergy);
            Conditions.Add(new WillNotCapComboPointsCondition());
            Conditions.Add(new ImStealthedCondition());
        }
    }
}

