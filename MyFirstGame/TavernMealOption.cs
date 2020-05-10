using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstGame
{
    class TavernMealOption
    {
        public string Name { get; set; }
        public int TavernLevel { get; set; }
        public int Cost { get; set; }
        public int BaseHitPointsRegeneration { get; set; } = 0;
        public int BaseManaPointsRegeneration { get; set; } = 0;


    }
}
