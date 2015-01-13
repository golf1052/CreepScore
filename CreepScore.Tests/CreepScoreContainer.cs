using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreepScoreAPI.Tests
{
    public sealed class CreepScoreContainer
    {
        private static readonly Lazy<CreepScore> lazy = new Lazy<CreepScore>(() => new CreepScore(ApiKey.apiKey, 10, 500));

        public static CreepScore Instance { get { return lazy.Value; } }

        private CreepScoreContainer()
        {
        }
    }
}
