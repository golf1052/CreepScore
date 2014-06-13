using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreepScoreAPI;
using Xunit;

namespace CreepScoreAPI.Tests
{
    public class CreepScoreTests
    {
        CreepScore creepScore;

        public CreepScoreTests()
        {
            creepScore = new CreepScore(ApiKey.apiKey);
        }
    }
}
