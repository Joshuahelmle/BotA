using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    class MinEnergyCondition : ICondition
    {
        private int _minEnergy;

       public  MinEnergyCondition(int minEnergy)
        {
            this._minEnergy = minEnergy;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage >= _minEnergy;
        }
    }
}
