using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Conditions.Auras
{
    class DoesHaveMinAuraStacksCondition : ICondition
    {

        private WoWSpell _spell;
        private int _stacks;

        public DoesHaveMinAuraStacksCondition(WoWSpell spell, int stacks)
        {
            _spell = spell;
            _stacks = stacks;
        }
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(_spell.Id) ? StyxWoW.Me.GetAuraById(_spell.Id).StackCount >= _stacks : (_stacks <= 0);
        }
    }
}
