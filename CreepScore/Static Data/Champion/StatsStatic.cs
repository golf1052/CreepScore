namespace CreepScoreAPI
{
    public class StatsStatic
    {
        public double armor;
        public double armorPerLevel;
        public double attackDamage;
        public double attackDamagePerLevel;
        public double attackRange;
        public double attackSpeedOffset;
        public double attackSpeedPerLevel;
        public double crit;
        public double critPerLevel;
        public double hp;
        public double hpPerLevel;
        public double hpRegen;
        public double hpRegenPerLevel;
        public double moveSpeed;
        public double mp;
        public double mpPerLevel;
        public double mpRegen;
        public double mpRegenPerLevel;
        public double spellBlock;
        public double spellBlockPerLevel;

        public StatsStatic(double armor,
            double armorPerLevel,
            double attackDamage,
            double attackDamagePerLevel,
            double attackRange,
            double attackSpeedOffset,
            double attackSpeedPerLevel,
            double crit,
            double critPerLevel,
            double hp,
            double hpPerLevel,
            double hpRegen,
            double hpRegenPerLevel,
            double moveSpeed,
            double mp,
            double mpPerLevel,
            double mpRegen,
            double mpRegenPerLevel,
            double spellBlock,
            double spellBlockPerLevel)
        {
            this.armor = armor;
            this.armorPerLevel = armorPerLevel;
            this.attackDamage = attackDamage;
            this.attackDamagePerLevel = attackDamagePerLevel;
            this.attackRange = attackRange;
            this.attackSpeedOffset = attackSpeedOffset;
            this.attackSpeedPerLevel = attackSpeedPerLevel;
            this.crit = crit;
            this.critPerLevel = critPerLevel;
            this.hp = hp;
            this.hpPerLevel = hpPerLevel;
            this.hpRegen = hpRegen;
            this.hpRegenPerLevel = hpRegenPerLevel;
            this.moveSpeed = moveSpeed;
            this.mp = mp;
            this.mpPerLevel = mpPerLevel;
            this.mpRegen = mpRegen;
            this.mpRegenPerLevel = mpRegenPerLevel;
            this.spellBlock = spellBlock;
            this.spellBlockPerLevel = spellBlockPerLevel;
        }
    }
}
