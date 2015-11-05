using System.Collections.Generic;
using System.Linq;

namespace BladeOfTheAssassin.Core.Conditions
{
    /// <summary>
    /// Condition dependency list where each condition must be satisfied to return true.
    /// </summary>
    public class ConditionAndList : List<ICondition>, ICondition
    {
        public ConditionAndList()
            : base()
        {
        }

        public ConditionAndList(params ICondition[] conditions)
        {
            this.AddRange(conditions);
        }

        public bool Satisfied()
        {
            return this.All(item => item.Satisfied());
        }

        
    }
}