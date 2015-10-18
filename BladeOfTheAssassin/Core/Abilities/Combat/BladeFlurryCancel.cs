using BladeOfTheAssassin.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System.Threading.Tasks;

namespace BladeOfTheAssassin.Core.Abilities.Combat
{
    public class BladeFlurryCancel : AbilityBase
    {
        public BladeFlurryCancel()
            : base(WoWSpell.FromId(SpellBook.CastBladeFlurry), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new TargetAuraUpCondition(Me, Spell));
        }

    }
}