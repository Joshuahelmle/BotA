using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    public class WillNotCapComboPointsCondition : ICondition
    {

        

        public WillNotCapComboPointsCondition()
        {
           
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraAnticipation) ? StyxWoW.Me.GetAuraById(SpellBook.AuraAnticipation).StackCount + StyxWoW.Me.ComboPoints +2 < 10 : true;
        }
    }
}