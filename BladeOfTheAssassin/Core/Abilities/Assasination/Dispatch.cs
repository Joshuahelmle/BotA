using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Assasination
{
    public class Dispatch : AbilityBase
    {
        ICondition Energy = new BladeOfTheAssassin.Core.Conditions.EnergyRangeCondition(30);
        public Dispatch()
            : base(WoWSpell.FromId(SpellBook.CastDispatch), true, false)
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
            Conditions.Add(new ConditionOrList(
                new TargetIsInHealthRangeCondition(target, 0, 35),
                    new ConditionAndList(
                    new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraBlindside)),
                    new ConditionOrList(
                        new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.CastEnvenom)),
                        new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(1), WoWSpell.FromId(SpellBook.AuraBlindside), Me))
                )));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.T184PEnabled),
                new WillNotCapComboPointsCondition(3),
                new WillNotCapComboPointsCondition(1)));
            return await base.CastOnTarget(target);
        }

    }
}

