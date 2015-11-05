using System;
using BladeOfTheAssassin.Core.Conditions;
using Styx.WoWInternals;
using BladeOfTheAssassin.Core.Conditions.Auras;
using System.Threading.Tasks;
using Styx.WoWInternals.WoWObjects;
using BladeOfTheAssassin.Core.Managers;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class FanOfKnives : AbilityBase
    {
        public FanOfKnives()
            : base(WoWSpell.FromId(SpellBook.CastFanOfKnives), true, false)
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
            Conditions.Add(new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraVanish)));
            //Conditions.Add(new ApplyPoisonToSurroundingCondition(UnitManager.Instance.LastKnownPoisonedEnemies));
            return await base.CastOnTarget(target);
        }

    }
}