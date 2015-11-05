using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class KillingSpree : AbilityBase
    {
        public KillingSpree() 
            : base(WoWSpell.FromId(SpellBook.CastKillingSpree), true, true)
        {
            Category = AbilityCategory.Combat;

        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseKillingSpree));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.KillingSpreeOnlyOnBoss),
                new OnlyOnBossCondition()));
            base.Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.CastAdrenalineRush)));
            return base.CastOnTarget(target);
        }

    }
}