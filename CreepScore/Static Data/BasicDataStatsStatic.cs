using System;
using System.Collections.Generic;

namespace CreepScoreAPI
{
    public class BasicDataStatsStatic
    {
        public double? flatArmorMod;
        public double? flatAttackSpeedMod;
        public double? flatBlockMod;
        public double? flatCritChanceMod;
        public double? flatCritDamageMod;
        public double? flatEXPBonus;
        public double? flatEnergyPoolMod;
        public double? flatEnergyRegenMod;
        public double? flatHPPoolMod;
        public double? flatHPRegenMod;
        public double? flatMPPoolMod;
        public double? flatMPRegenMod;
        public double? flatMagicDamageMod;
        public double? flatMovementSpeedMod;
        public double? flatPhysicalDamageMod;
        public double? flatSpellBlockMod;
        public double? percentArmorMod;
        public double? percentAttackSpeedMod;
        public double? percentBlockMod;
        public double? percentCritChanceMod;
        public double? percentCritDamageMod;
        public double? percentDodgeMod;
        public double? percentEXPBonus;
        public double? percentHPPoolMod;
        public double? percentHPRegenMod;
        public double? percentLifeStealMod;
        public double? percentMPPoolMod;
        public double? percentMPRegenMod;
        public double? percentMagicDamageMod;
        public double? percentMovementSpeedMod;
        public double? percentPhysicalDamageMod;
        public double? percentSpellBlockMod;
        public double? percentSpellVampMod;
        public double? rFlatArmorModPerLevel;
        public double? rFlatArmorPenetrationMod;
        public double? rFlatArmorPenetrationModPerLevel;
        public double? rFlatCritChanceModPerLevel;
        public double? rFlatCritDamageModPerLevel;
        public double? rFlatDodgeMod;
        public double? rFlatDodgeModPerLevel;
        public double? rFlatEnergyModPerLevel;
        public double? rFlatEnergyRegenModPerLevel;
        public double? rFlatGoldPer10Mod;
        public double? rFlatHPModPerLevel;
        public double? rFlatHPRegenModPerLevel;
        public double? rFlatMPModPerLevel;
        public double? rFlatMPRegenModPerLevel;
        public double? rFlatMagicDamageModPerLevel;
        public double? rFlatMagicPenetrationMod;
        public double? rFlatMagicPenetrationModPerLevel;
        public double? rFlatMovementSpeedModPerLevel;
        public double? rFlatPhysicalDamageModPerLevel;
        public double? rFlatSpellBlockModPerLevel;
        public double? rFlatTimeDeadMod;
        public double? rFlatTimeDeadModPerLevel;
        public double? rPercentArmorPenetrationMod;
        public double? rPercentArmorPenetrationModPerLevel;
        public double? rPercentAttackSpeedModPerLevel;
        public double? rPercentCooldownMod;
        public double? rPercentCooldownModPerLevel;
        public double? rPercentMagicPenetrationMod;
        public double? rPercentMagicPenetrationModPerLevel;
        public double? rPercentMovementSpeedModPerLevel;
        public double? rPercentTimeDeadMod;
        public double? rPercentTimeDeadModPerLeveldouble;
        public List<double?> values;

        public BasicDataStatsStatic(double? flatArmorMod,
            double? flatAttackSpeedMod,
            double? flatBlockMod,
            double? flatCritChanceMod,
            double? flatCritDamageMod,
            double? flatEXPBonus,
            double? flatEnergyPoolMod,
            double? flatEnergyRegenMod,
            double? flatHPPoolMod,
            double? flatHPRegenMod,
            double? flatMPPoolMod,
            double? flatMPRegenMod,
            double? flatMagicDamageMod,
            double? flatMovementSpeedMod,
            double? flatPhysicalDamageMod,
            double? flatSpellBlockMod,
            double? percentArmorMod,
            double? percentAttackSpeedMod,
            double? percentBlockMod,
            double? percentCritChanceMod,
            double? percentCritDamageMod,
            double? percentDodgeMod,
            double? percentEXPBonus,
            double? percentHPPoolMod,
            double? percentHPRegenMod,
            double? percentLifeStealMod,
            double? percentMPPoolMod,
            double? percentMPRegenMod,
            double? percentMagicDamageMod,
            double? percentMovementSpeedMod,
            double? percentPhysicalDamageMod,
            double? percentSpellBlockMod,
            double? percentSpellVampMod,
            double? rFlatArmorModPerLevel,
            double? rFlatArmorPenetrationMod,
            double? rFlatArmorPenetrationModPerLevel,
            double? rFlatCritChanceModPerLevel,
            double? rFlatCritDamageModPerLevel,
            double? rFlatDodgeMod,
            double? rFlatDodgeModPerLevel,
            double? rFlatEnergyModPerLevel,
            double? rFlatEnergyRegenModPerLevel,
            double? rFlatGoldPer10Mod,
            double? rFlatHPModPerLevel,
            double? rFlatHPRegenModPerLevel,
            double? rFlatMPModPerLevel,
            double? rFlatMPRegenModPerLevel,
            double? rFlatMagicDamageModPerLevel,
            double? rFlatMagicPenetrationMod,
            double? rFlatMagicPenetrationModPerLevel,
            double? rFlatMovementSpeedModPerLevel,
            double? rFlatPhysicalDamageModPerLevel,
            double? rFlatSpellBlockModPerLevel,
            double? rFlatTimeDeadMod,
            double? rFlatTimeDeadModPerLevel,
            double? rPercentArmorPenetrationMod,
            double? rPercentArmorPenetrationModPerLevel,
            double? rPercentAttackSpeedModPerLevel,
            double? rPercentCooldownMod,
            double? rPercentCooldownModPerLevel,
            double? rPercentMagicPenetrationMod,
            double? rPercentMagicPenetrationModPerLevel,
            double? rPercentMovementSpeedModPerLevel,
            double? rPercentTimeDeadMod,
            double? rPercentTimeDeadModPerLeveldouble)
        {
            values = new List<double?>();
            this.flatArmorMod = flatArmorMod;
            this.flatAttackSpeedMod = flatAttackSpeedMod;
            this.flatBlockMod = flatBlockMod;
            this.flatCritChanceMod = flatCritChanceMod;
            this.flatCritDamageMod = flatCritDamageMod;
            this.flatEXPBonus = flatEXPBonus;
            this.flatEnergyPoolMod = flatEnergyPoolMod;
            this.flatEnergyRegenMod = flatEnergyRegenMod;
            this.flatHPPoolMod = flatHPPoolMod;
            this.flatHPRegenMod = flatHPRegenMod;
            this.flatMPPoolMod = flatMPPoolMod;
            this.flatMPRegenMod = flatMPRegenMod;
            this.flatMagicDamageMod = flatMagicDamageMod;
            this.flatMovementSpeedMod = flatMovementSpeedMod;
            this.flatPhysicalDamageMod = flatPhysicalDamageMod;
            this.flatSpellBlockMod = flatSpellBlockMod;
            this.percentArmorMod = percentArmorMod;
            this.percentAttackSpeedMod = percentAttackSpeedMod;
            this.percentBlockMod = percentBlockMod;
            this.percentCritChanceMod = percentCritChanceMod;
            this.percentCritDamageMod = percentCritDamageMod;
            this.percentDodgeMod = percentDodgeMod;
            this.percentEXPBonus = percentEXPBonus;
            this.percentHPPoolMod = percentHPPoolMod;
            this.percentHPRegenMod = percentHPRegenMod;
            this.percentLifeStealMod = percentLifeStealMod;
            this.percentMPPoolMod = percentMPPoolMod;
            this.percentMPRegenMod = percentMPRegenMod;
            this.percentMagicDamageMod = percentMagicDamageMod;
            this.percentMovementSpeedMod = percentMovementSpeedMod;
            this.percentPhysicalDamageMod = percentPhysicalDamageMod;
            this.percentSpellBlockMod = percentSpellBlockMod;
            this.percentSpellVampMod = percentSpellVampMod;
            this.rFlatArmorModPerLevel = rFlatArmorModPerLevel;
            this.rFlatArmorPenetrationMod = rFlatArmorPenetrationMod;
            this.rFlatArmorPenetrationModPerLevel = rFlatArmorPenetrationModPerLevel;
            this.rFlatCritChanceModPerLevel = rFlatCritChanceModPerLevel;
            this.rFlatCritDamageModPerLevel = rFlatCritDamageModPerLevel;
            this.rFlatDodgeMod = rFlatDodgeMod;
            this.rFlatDodgeModPerLevel = rFlatDodgeModPerLevel;
            this.rFlatEnergyModPerLevel = rFlatEnergyModPerLevel;
            this.rFlatEnergyRegenModPerLevel = rFlatEnergyRegenModPerLevel;
            this.rFlatGoldPer10Mod = rFlatGoldPer10Mod;
            this.rFlatHPModPerLevel = rFlatHPModPerLevel;
            this.rFlatHPRegenModPerLevel = rFlatHPRegenModPerLevel;
            this.rFlatMPModPerLevel = rFlatMPModPerLevel;
            this.rFlatMPRegenModPerLevel = rFlatMPRegenModPerLevel;
            this.rFlatMagicDamageModPerLevel = rFlatMagicDamageModPerLevel;
            this.rFlatMagicPenetrationMod = rFlatMagicPenetrationMod;
            this.rFlatMagicPenetrationModPerLevel = rFlatMagicPenetrationModPerLevel;
            this.rFlatMovementSpeedModPerLevel = rFlatMovementSpeedModPerLevel;
            this.rFlatPhysicalDamageModPerLevel = rFlatPhysicalDamageModPerLevel;
            this.rFlatSpellBlockModPerLevel = rFlatSpellBlockModPerLevel;
            this.rFlatTimeDeadMod = rFlatTimeDeadMod;
            this.rFlatTimeDeadModPerLevel = rFlatTimeDeadModPerLevel;
            this.rPercentArmorPenetrationMod = rPercentArmorPenetrationMod;
            this.rPercentArmorPenetrationModPerLevel = rPercentArmorPenetrationModPerLevel;
            this.rPercentAttackSpeedModPerLevel = rPercentAttackSpeedModPerLevel;
            this.rPercentCooldownMod = rPercentCooldownMod;
            this.rPercentCooldownModPerLevel = rPercentCooldownModPerLevel;
            this.rPercentMagicPenetrationMod = rPercentMagicPenetrationMod;
            this.rPercentMagicPenetrationModPerLevel = rPercentMagicPenetrationModPerLevel;
            this.rPercentMovementSpeedModPerLevel = rPercentMovementSpeedModPerLevel;
            this.rPercentTimeDeadMod = rPercentTimeDeadMod;
            this.rPercentTimeDeadModPerLeveldouble = rPercentTimeDeadModPerLeveldouble;

            values.Add(flatArmorMod);
            values.Add(flatAttackSpeedMod);
            values.Add(flatBlockMod);
            values.Add(flatCritChanceMod);
            values.Add(flatCritDamageMod);
            values.Add(flatEXPBonus);
            values.Add(flatEnergyPoolMod);
            values.Add(flatEnergyRegenMod);
            values.Add(flatHPPoolMod);
            values.Add(flatHPRegenMod);
            values.Add(flatMPPoolMod);
            values.Add(flatMPRegenMod);
            values.Add(flatMagicDamageMod);
            values.Add(flatMovementSpeedMod);
            values.Add(flatPhysicalDamageMod);
            values.Add(flatSpellBlockMod);
            values.Add(percentArmorMod);
            values.Add(percentAttackSpeedMod);
            values.Add(percentBlockMod);
            values.Add(percentCritChanceMod);
            values.Add(percentCritDamageMod);
            values.Add(percentDodgeMod);
            values.Add(percentEXPBonus);
            values.Add(percentHPPoolMod);
            values.Add(percentHPRegenMod);
            values.Add(percentLifeStealMod);
            values.Add(percentMPPoolMod);
            values.Add(percentMPRegenMod);
            values.Add(percentMagicDamageMod);
            values.Add(percentMovementSpeedMod);
            values.Add(percentPhysicalDamageMod);
            values.Add(percentSpellBlockMod);
            values.Add(percentSpellVampMod);
            values.Add(rFlatArmorModPerLevel);
            values.Add(rFlatArmorPenetrationMod);
            values.Add(rFlatArmorPenetrationModPerLevel);
            values.Add(rFlatCritChanceModPerLevel);
            values.Add(rFlatCritDamageModPerLevel);
            values.Add(rFlatDodgeMod);
            values.Add(rFlatDodgeModPerLevel);
            values.Add(rFlatEnergyModPerLevel);
            values.Add(rFlatEnergyRegenModPerLevel);
            values.Add(rFlatGoldPer10Mod);
            values.Add(rFlatHPModPerLevel);
            values.Add(rFlatHPRegenModPerLevel);
            values.Add(rFlatMPModPerLevel);
            values.Add(rFlatMPRegenModPerLevel);
            values.Add(rFlatMagicDamageModPerLevel);
            values.Add(rFlatMagicPenetrationMod);
            values.Add(rFlatMagicPenetrationModPerLevel);
            values.Add(rFlatMovementSpeedModPerLevel);
            values.Add(rFlatPhysicalDamageModPerLevel);
            values.Add(rFlatSpellBlockModPerLevel);
            values.Add(rFlatTimeDeadMod);
            values.Add(rFlatTimeDeadModPerLevel);
            values.Add(rPercentArmorPenetrationMod);
            values.Add(rPercentArmorPenetrationModPerLevel);
            values.Add(rPercentAttackSpeedModPerLevel);
            values.Add(rPercentCooldownMod);
            values.Add(rPercentCooldownModPerLevel);
            values.Add(rPercentMagicPenetrationMod);
            values.Add(rPercentMagicPenetrationModPerLevel);
            values.Add(rPercentMovementSpeedModPerLevel);
            values.Add(rPercentTimeDeadMod);
            values.Add(rPercentTimeDeadModPerLeveldouble);
        }
    }
}
