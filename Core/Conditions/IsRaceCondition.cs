using Styx;

namespace BladeOfTheAssassin.Core.Conditions
{
    /// <summary>
    /// Checks wheter we are the given race.
    /// </summary>
    class IsRaceCondition : ICondition
    {

        /// <summary>
        /// the Race to check for
        /// </summary>
        private WoWRace _race;

       public  IsRaceCondition(WoWRace race)
        {
            this._race = race;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.Race == _race;
        }
    }
}
