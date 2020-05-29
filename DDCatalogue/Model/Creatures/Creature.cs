﻿using DDCatalogue.Model.Joins;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDCatalogue.Model.Creatures
{
    public class Creature : ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        public JArray Proficiencies { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Size { get; set; }
        public JArray Speed { get; set; }
        public string Languages { get; set; }
        public Alignment Alignment { get; set; }
        public JArray Reactions { get; set; }
        public string Picture { get; set; }
    }

    public enum Alignment
    {
        LG,
        LN,
        LE,
        NG,
        TN,
        NE,
        CG,
        CN,
        CE,
        Any,
        None
    }

}
