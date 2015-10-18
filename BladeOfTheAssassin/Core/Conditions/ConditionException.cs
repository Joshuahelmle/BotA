using System;

namespace BladeOfTheAssassin.Core.Conditions
{
    class ConditionException : Exception
    {
         public ConditionException(string message)
            : base(message)
        {

        }
    }
}
