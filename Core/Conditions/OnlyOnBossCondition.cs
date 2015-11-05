using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    internal class OnlyOnBossCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentTarget.IsBoss;
        }
    }
}