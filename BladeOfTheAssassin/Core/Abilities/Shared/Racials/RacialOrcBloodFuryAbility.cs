using BladeOfTheAssassin.Core.Conditions;
using BladeOfTheAssassin.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace BladeOfTheAssassin.Core.Abilities.Shared.Racials
{
    class RacialOrcBloodFuryAbility : AbilityBase
    {
       public RacialOrcBloodFuryAbility()
            : base(WoWSpell.FromId(SpellBook.RacialOrcBloodFury), false, true)
        {
           base.Category = AbilityCategory.Buff;
           base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseOrcRacial));
           base.Conditions.Add(new IsRaceCondition(WoWRace.Orc));
          
          
       }
       
        }
    }

