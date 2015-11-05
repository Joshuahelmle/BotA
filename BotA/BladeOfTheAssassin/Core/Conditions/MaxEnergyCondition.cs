using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    class MaxEnergyCondition : ICondition
    {
        private int _maxEnergy;

       public MaxEnergyCondition(int maxEnergy)
        {
            this._maxEnergy = maxEnergy;
        }
        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentEnergy <= _maxEnergy;
        }
    }
}
