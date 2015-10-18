using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    class EnergyRangeCondition : ICondition
    {

        private int _minEnergy, _maxEnergy;

        public EnergyRangeCondition(int minEnergy, int maxEnergy = 200)
        {
            _minEnergy = minEnergy;
            _maxEnergy = maxEnergy;
        }

        public bool Satisfied()
        {
            if (_minEnergy > _maxEnergy)
            {
                throw new ConditionException("MinEnergy can't be higher than max energy");
            }
            if (_maxEnergy < _minEnergy)
            {
                throw new ConditionException("maxEnergy cant be lower than minEnergy");
            }

            return StyxWoW.Me.CurrentEnergy >= _minEnergy && StyxWoW.Me.CurrentEnergy <= _maxEnergy;
        }
    }
}
