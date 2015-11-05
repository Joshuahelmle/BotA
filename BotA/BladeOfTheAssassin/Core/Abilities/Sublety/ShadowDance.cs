using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class ShadowDance : AbilityBase
    {
        public ShadowDance()
            : base(WoWSpell.FromId(SpellBook.AuraShadowDance), false, true)
        {
            Category = AbilityCategory.Buff;
            
        }



        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            InitializeBase();
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseShadowDance));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new ConditionOrList(
                new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.CastShadowReflection)),
                new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.CastShadowReflection), TimeSpan.FromSeconds(40))));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.ShadowDanceOnlyOnBoss),
                new OnlyOnBossCondition()));
            return base.CastOnTarget(target);
        }
    }
}