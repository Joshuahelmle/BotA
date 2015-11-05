using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class AdrenalineRush : AbilityBase
    {
        public AdrenalineRush()
            : base(WoWSpell.FromId(SpellBook.CastAdrenalineRush), false, true)
        {
            Category = AbilityCategory.Combat;

        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseAdrenalineRush));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.AdrenalineRushOnlyOnBoss),
                new OnlyOnBossCondition()));
            return base.CastOnTarget(target);
        }
    }
}