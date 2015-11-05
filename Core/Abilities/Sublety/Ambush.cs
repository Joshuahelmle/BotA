using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;


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
            Conditions.Add(new WillNotCapComboPointsCondition(2));
            Conditions.Add(new ImStealthedCondition());
        }
    }
}

