using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DQModEditor.Model
{
    /// <summary>
    /// Represents information about how an enemy spawns another enemy on death.
    /// </summary>
    public class SpawnInfo
    {
        public SpawnInfo(string spawnId, SpawnLocation location)
        {
            SpawnsId = spawnId;
            Location = location;
        }

        public string SpawnsId { get; set; }
        public string EffectId { get; set; }
        public SpawnLocation Location { get; set; }

        public struct SpawnLocation
        {
            public SpawnLocation(decimal x, decimal y)
            {
                X = x;
                Y = y;
            }

            decimal X { get; }
            decimal Y { get; }
        }
    }
}
