using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using BladeOfTheAssassin.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Assasination
{
    public class Vendetta : AbilityBase
    {
        public Vendetta()
            : base(WoWSpell.FromId(SpellBook.CastVendetta), true, true)
        {
            Category = AbilityCategory.Buff;
        }


        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseVendetta));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.VendettaOnlyOnBoss),
                new OnlyOnBossCondition()));
            Conditions.Add(new BooleanCondition(target != null));
            Conditions.Add(new InMeeleRangeCondition(target));
            Conditions.Add(new TargetAuraUpCondition(target, WoWSpell.FromId(SpellBook.CastRupture)));
            return await base.CastOnTarget(target);
        }

    }
}

