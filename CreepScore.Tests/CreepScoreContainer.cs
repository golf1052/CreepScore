using System;

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
