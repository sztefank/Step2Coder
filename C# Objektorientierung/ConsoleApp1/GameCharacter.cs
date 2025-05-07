using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GameCharacter
    {
        // Attribute
        public Dictionary<string, Tuple<int>> items = new Dictionary<string, Tuple<int>>(6);

        public List<string> buffs = new List<string>();

        public int gold;
        public int level;
        public int current_xp;
        public int base_attack_range;
        public int attack_range;
        public int critical_strike_chance;
        public int lethality;
        public int flat_magic_penetration;
        public int lifesteal;
        public int physical_vamp;
        public int rage;
        public int omnivamp;

        public double base_health;
        public double health;
        public double health_growth;

        public double base_armor;
        public double armor;
        public double armor_growth;

        public double base_magic_resistance;
        public double magic_resistance;
        public double magic_resistance_growth;

        public double base_attack_damage;
        public double attack_damage;
        public double attack_damage_growth;

        public double base_attack_speed;
        public double attack_speed;
        public double attack_speed_growth;

        public double base_ability_power;
        public double ability_power;
        public double ability_power_growth;

        public double base_ability_haste;
        public double ability_haste;
        public double ability_haste_growth;

        public double base_movement_speed;
        public double movement_speed;

        public double base_mana_regeneration;
        public double mana_regeneration;

        public double base_health_regeneration;
        public double health_regeneration;

        public double energy;
        public double energy_regeneration;

        public double heal_shield_power;
        public double tenacity;
        public double slow_resist;
        public double armor_penetration;
        public double magic_penetration;

        public bool alive;

        public string username;
        public string skin;

        public GameCharacter()
        {
            gold = 0;
            level = 1;
            current_xp = 0;
            critical_strike_chance = 0;
        }
    }
}
