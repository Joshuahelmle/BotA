using System;
using System.Threading.Tasks;
using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class BurstOfSpeedAbility : AbilityBase
    {
        ICondition Energy = new EnergyRangeCondition(30);
        public BurstOfSpeedAbility() : base(WoWSpell.FromId(SpellBook.CastBurstOfSpeed), false, true)
        {
            base.Category = AbilityCategory.Buff;
            
        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            InitializeBase();
            Conditions.Add(new BooleanCondition(Me.IsMoving));
            Conditions.Add(Energy);
            Conditions.Add(new ConditionOrList(
                new TargetNotAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraBurstofSpeed)),
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(0.5), WoWSpell.FromId(SpellBook.AuraBurstofSpeed),Me)));
            Conditions.Add(new ConditionOrList(
                new ConditionAndList(
                    new EnergyRangeCondition(70), new BooleanCondition(!Me.HasAttackableTarget())),
                    new TargetMinRangeCondition(target, 10),
                    new BooleanCondition(Me.HasRootOrSnare())));
            return base.CastOnTarget(target);
        }
    }
}