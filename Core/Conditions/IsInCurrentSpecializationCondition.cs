using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    class IsInCurrentSpecializationCondition :ICondition
    {

        private WoWSpec _currentSpec;

       public IsInCurrentSpecializationCondition(WoWSpec currentSpec)
        {
            this._currentSpec = currentSpec;
        }
        public bool Satisfied()
        {
            return StyxWoW.Me.Specialization == _currentSpec;
        }
    }
}
