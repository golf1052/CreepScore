using System;

namespace CreepScoreAPI
{
    /// <summary>
    /// RuneSlot class
    /// </summary>
    public class RuneSlot
    {
        /// <summary>
        /// Rune ID associated with the rune slot
        /// </summary>
        public int runeId;

        /// <summary>
        /// Rune slot ID
        /// </summary>
        public int runeSlotId;

        /// <summary>
        /// RuneSlot constructor
        /// </summary>
        /// <param name="runeId">Rune ID associated with the rune slot</param>
        /// <param name="runeSlotId">Rune slot ID</param>
        public RuneSlot(int runeId, int runeSlotId)
        {
            this.runeId = runeId;
            this.runeSlotId = runeSlotId;
        }
    }
}
