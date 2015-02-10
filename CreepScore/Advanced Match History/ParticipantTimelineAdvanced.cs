using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ParticipantTimelineAdvanced
    {
        /// <summary>
        /// Ancient golem assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced ancientGolemAssistsPerMinCounts;

        /// <summary>
        /// Ancient golem kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced ancientGolemKillsPerMinCounts;

        /// <summary>
        /// Assisted lane deaths per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced assistedLaneDeathsPerMinDeltas;

        /// <summary>
        /// Assisted lane kills per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced assistedLaneKillsPerMinDeltas;

        /// <summary>
        /// Baron assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced baronAssistsPerMinCounts;

        /// <summary>
        /// Baron kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced baronKillsPerMinCounts;

        /// <summary>
        /// Creeps per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced creepsPerMinDeltas;

        /// <summary>
        /// Creep score difference per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced csDiffPerMinDeltas;

        /// <summary>
        /// Damage taken difference per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced damageTakenDiffPerMinDeltas;

        /// <summary>
        /// Damage taken per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced damageTakenPerMinDeltas;

        /// <summary>
        /// Dragon assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced dragonAssistsPerMinCounts;

        /// <summary>
        /// Dragon kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced dragonKillsPerMinCounts;

        /// <summary>
        /// Elder lizard assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced elderLizardAssistsPerMinCounts;

        /// <summary>
        /// Elder lizard kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced elderLizardKillsPerMinCounts;

        /// <summary>
        /// Gold per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced goldPerMinDeltas;

        /// <summary>
        /// Inhibitor assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced inhibitorAssistsPerMinCounts;

        /// <summary>
        /// Inhibitor kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced inhibitorKillsPerMinCounts;

        /// <summary>
        /// Participant's lane
        /// </summary>
        public string lane;

        /// <summary>
        /// Participant's role
        /// </summary>
        public string role;

        /// <summary>
        /// Tower assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced towerAssistsPerMinCounts;

        /// <summary>
        /// Tower kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced towerKillsPerMinCounts;

        /// <summary>
        /// Tower kills per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced towerKillsPerMinDeltas;

        /// <summary>
        /// Vilemaw assists per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced vilemawAssistsPerMinCounts;

        /// <summary>
        /// Vilemaw kills per minute timeline counts
        /// </summary>
        public ParticipantTimelineDataAdvanced vilemawKillsPerMinCounts;

        /// <summary>
        /// Wards placed per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced wardsPerMinDeltas;

        /// <summary>
        /// Experience difference per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced xpDiffPerMinDeltas;

        /// <summary>
        /// Experience per minute timeline data
        /// </summary>
        public ParticipantTimelineDataAdvanced xpPerMinDeltas;

        public ParticipantTimelineAdvanced(JObject ancientGolemAssistsPerMinCountsO,
            JObject ancientGolemKillsPerMinCountsO,
            JObject assistedLaneDeathsPerMinDeltasO,
            JObject assistedLaneKillsPerMinDeltasO,
            JObject baronAssistsPerMinCountsO,
            JObject baronKillsPerMinCountsO,
            JObject creepsPerMinDeltasO,
            JObject csDiffPerMinDeltasO,
            JObject damageTakenDiffPerMinDeltasO,
            JObject damageTakenPerMinDeltasO,
            JObject dragonAssistsPerMinCountsO,
            JObject dragonKillsPerMinCountsO,
            JObject elderLizardAssistsPerMinCountsO,
            JObject elderLizardKillsPerMinCountsO,
            JObject goldPerMinDeltasO,
            JObject inhibitorAssistsPerMinCountsO,
            JObject inhibitorKillsPerMinCountsO,
            string lane,
            string role,
            JObject towerAssistsPerMinCountsO,
            JObject towerKillsPerMinCountsO,
            JObject towerKillsPerMinDeltasO,
            JObject vilemawAssistsPerMinCountsO,
            JObject vilemawKillsPerMinCountsO,
            JObject wardsPerMinDeltasO,
            JObject xpDiffPerMinDeltasO,
            JObject xpPerMinDeltasO)
        {
            if (ancientGolemAssistsPerMinCountsO != null)
            {
                this.ancientGolemAssistsPerMinCounts = LoadParticipantTimelineData(ancientGolemAssistsPerMinCountsO);
            }

            if (ancientGolemKillsPerMinCounts != null)
            {
                this.ancientGolemKillsPerMinCounts = LoadParticipantTimelineData(ancientGolemKillsPerMinCountsO);
            }

            if (assistedLaneDeathsPerMinDeltas != null)
            {
                this.assistedLaneDeathsPerMinDeltas = LoadParticipantTimelineData(assistedLaneDeathsPerMinDeltasO);
            }

            if (assistedLaneKillsPerMinDeltas != null)
            {
                this.assistedLaneKillsPerMinDeltas = LoadParticipantTimelineData(assistedLaneKillsPerMinDeltasO);
            }

            if (baronAssistsPerMinCounts != null)
            {
                this.baronAssistsPerMinCounts = LoadParticipantTimelineData(baronAssistsPerMinCountsO);
            }

            if (baronKillsPerMinCounts != null)
            {
                this.baronKillsPerMinCounts = LoadParticipantTimelineData(baronKillsPerMinCountsO);
            }

            if (creepsPerMinDeltas != null)
            {
                this.creepsPerMinDeltas = LoadParticipantTimelineData(creepsPerMinDeltasO);
            }

            if (csDiffPerMinDeltas != null)
            {
                this.csDiffPerMinDeltas = LoadParticipantTimelineData(csDiffPerMinDeltasO);
            }

            if (damageTakenDiffPerMinDeltas != null)
            {
                this.damageTakenDiffPerMinDeltas = LoadParticipantTimelineData(damageTakenDiffPerMinDeltasO);
            }

            if (damageTakenPerMinDeltas != null)
            {
                this.damageTakenPerMinDeltas = LoadParticipantTimelineData(damageTakenPerMinDeltasO);
            }

            if (dragonAssistsPerMinCounts != null)
            {
                this.dragonAssistsPerMinCounts = LoadParticipantTimelineData(dragonAssistsPerMinCountsO);
            }

            if (dragonKillsPerMinCounts != null)
            {
                this.dragonKillsPerMinCounts = LoadParticipantTimelineData(dragonKillsPerMinCountsO);
            }

            if (elderLizardAssistsPerMinCounts != null)
            {
                this.elderLizardAssistsPerMinCounts = LoadParticipantTimelineData(elderLizardAssistsPerMinCountsO);
            }

            if (elderLizardKillsPerMinCounts != null)
            {
                this.elderLizardKillsPerMinCounts = LoadParticipantTimelineData(elderLizardKillsPerMinCountsO);
            }

            if (goldPerMinDeltas != null)
            {
                this.goldPerMinDeltas = LoadParticipantTimelineData(goldPerMinDeltasO);
            }

            if (inhibitorAssistsPerMinCounts != null)
            {
                this.inhibitorAssistsPerMinCounts = LoadParticipantTimelineData(inhibitorAssistsPerMinCountsO);
            }

            if (inhibitorKillsPerMinCounts != null)
            {
                this.inhibitorKillsPerMinCounts = LoadParticipantTimelineData(inhibitorKillsPerMinCountsO);
            }

            this.lane = lane;
            this.role = role;

            if (towerAssistsPerMinCounts != null)
            {
                this.towerAssistsPerMinCounts = LoadParticipantTimelineData(towerAssistsPerMinCountsO);
            }

            if (towerKillsPerMinCounts != null)
            {
                this.towerKillsPerMinCounts = LoadParticipantTimelineData(towerKillsPerMinCountsO);
            }

            if (towerKillsPerMinDeltas != null)
            {
                this.towerKillsPerMinDeltas = LoadParticipantTimelineData(towerKillsPerMinDeltasO);
            }

            if (vilemawAssistsPerMinCounts != null)
            {
                this.vilemawAssistsPerMinCounts = LoadParticipantTimelineData(vilemawAssistsPerMinCountsO);
            }

            if (vilemawKillsPerMinCounts != null)
            {
                this.vilemawKillsPerMinCounts = LoadParticipantTimelineData(vilemawKillsPerMinCountsO);
            }

            if (wardsPerMinDeltas != null)
            {
                this.wardsPerMinDeltas = LoadParticipantTimelineData(wardsPerMinDeltasO);
            }

            if (xpDiffPerMinDeltas != null)
            {
                this.xpDiffPerMinDeltas = LoadParticipantTimelineData(xpDiffPerMinDeltasO);
            }

            if (xpPerMinDeltas != null)
            {
                this.xpPerMinDeltas = LoadParticipantTimelineData(xpPerMinDeltasO);
            }
        }

        ParticipantTimelineDataAdvanced LoadParticipantTimelineData(JObject o)
        {
            return new ParticipantTimelineDataAdvanced((double)o["tenToTwenty"],
                (double)o["thirtyToEnd"],
                (double)o["twentyToThirty"],
                (double)o["zeroToTen"]);
        }
    }
}
