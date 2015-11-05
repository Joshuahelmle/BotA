using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Assasination
{
    public class Envenom : AbilityBase
    {
        ICondition Energy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(35);
        public Envenom()
            : base(WoWSpell.FromId(SpellBook.CastEnvenom), true, false)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(Energy);
            Conditions.Add(new ConditionOrList(
                new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.CastEnvenom)),
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(1), WoWSpell.FromId(SpellBook.CastEnvenom), Me),
                new ConditionAndList(
                    new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraAnticipation), 3),
                    new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraAnticipation))))); 
            Conditions.Add(new ComboPointCondition(5));

        }
    }
}

