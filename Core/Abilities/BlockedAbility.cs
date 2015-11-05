using System;

namespace BladeOfTheAssassin.Core.Abilities
{
    public sealed class BlockedAbility
    {
        public IAbility Ability { get; set; }
        public DateTime BlockedDateAndTime { get; set; }

        public BlockedAbility(IAbility ability, DateTime dateTime)
        {
            this.Ability = ability;
            this.BlockedDateAndTime = dateTime;
        }
    }
}
