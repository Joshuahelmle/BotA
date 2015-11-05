using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class WillNotCapComboPointsCondition : ICondition
    {

        private int _generates;
        

        public WillNotCapComboPointsCondition(int generates)
        {
            _generates = generates;
        }

        public bool Satisfied()
        {
            if (StyxWoW.Me.KnowsSpell(SpellBook.TalentAnticipation)){
                return StyxWoW.Me.HasAura(SpellBook.AuraAnticipation) ? StyxWoW.Me.GetAuraById(SpellBook.AuraAnticipation).StackCount + _generates <= 5 : StyxWoW.Me.ComboPoints + _generates <= 10;
            }

            return StyxWoW.Me.ComboPoints + _generates <= 5;
        }
    }
}