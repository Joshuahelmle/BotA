using Styx;

namespace BladeOfTheAssassin.Core.Conditions.Auras
{
    class DoesNotHaveAttackPowerBuffCondition : ICondition
    {
        public bool Satisfied()
        {
           return !StyxWoW.Me.HasAttackPowerBuff();
        }
    }
}
