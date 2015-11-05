using System;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions.Auras
{
    class AuraMaxRemaningTimeCondition : ICondition
    {

        private TimeSpan _maxRemaingTime;
        private WoWSpell _aura;
        private WoWUnit _target;

       public AuraMaxRemaningTimeCondition(TimeSpan maxRemaingTime, WoWSpell aura, WoWUnit target)
        {
            _maxRemaingTime = maxRemaingTime;
            _aura = aura;
            _target = target;
        }

        public bool Satisfied()
        {
            return _target != null && _target.AuraExists(_aura.Id, true) &&
                   _target.AuraRemainingTime(_aura.Id, true) < _maxRemaingTime;
        }
    }
}
