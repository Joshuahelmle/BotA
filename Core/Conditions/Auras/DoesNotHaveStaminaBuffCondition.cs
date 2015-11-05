using Styx;

namespace BladeOfTheAssassin.Core.Conditions.Auras
{
    class DoesNotHaveStaminaBuffCondition : ICondition
    {
        public bool Satisfied()
        {
           return !StyxWoW.Me.HasStaminaBuff();
        }
    }
}
