using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace BladeOfTheAssassin.Core.Conditions.Auras
{
    class TargetNotAuraUpCondition : ICondition
    {

        private WoWUnit _target;
        private WoWSpell _aura;
        private bool _isMine;

        public TargetNotAuraUpCondition(WoWUnit target, WoWSpell aura, bool isMine = true)
        {
            _target = target;
            _aura = aura;
            _isMine = isMine;
        }

        public bool Satisfied()
        {
            return  _target != null && !_target.AuraExists(_aura.Id, _isMine);
        }
    }
}
