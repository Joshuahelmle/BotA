using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions
{
    class TargetIsInHealthRangeCondition :ICondition
    {

        private int _minHealthPercentage, _maxHealthPercentage;
        private WoWUnit _target;
       public TargetIsInHealthRangeCondition(WoWUnit target, int minHealthPercentage = 0, int maxHealtPercentage = 100)
        {
           _target = target;
           this._minHealthPercentage = minHealthPercentage;
            this._maxHealthPercentage = maxHealtPercentage;
        }

        public bool Satisfied()
        {
            if (_minHealthPercentage > _maxHealthPercentage)
                throw new ConditionException("minHealth can't be bigger than maxHealth!");
            else if (_maxHealthPercentage < _minHealthPercentage)
                throw new ConditionException("maxhealth can't be smaller than minhealth!");
            return _target != null && _target.HealthPercent >= _minHealthPercentage &&
                     _target.HealthPercent <= _maxHealthPercentage;
        }

        
    }
}
