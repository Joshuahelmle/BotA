using System.Collections.Generic;
using System.Linq;

namespace BladeOfTheAssassin.Core.Conditions
{
    /// <summary>
    /// Condition list that returns true if any condition is satisfied.
    /// </summary>
    public class ConditionOrList : List<ICondition>, ICondition
    {
        public ConditionOrList()
            : base()
        { }

        public ConditionOrList(params ICondition[] conditions)
        {
            this.AddRange(conditions);
        }

        public bool Satisfied()
        {
            return this.Any(condition => condition.Satisfied());
        }




        
       

    }
}