﻿]using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model
{
    public class Monster : Creature
    {
        public Monster(string name, int ac, int hp, Alignment alignment) : base(name, ac, hp, alignment) { }
        public string Senses { get; set; }
        public double Challenge { get; set; }
        public int DefeatXp { get; set; }
        public int Pp { get; set; }
        public string[] Actions { get; set; }
        public string[] LegendaryActions { get; set; }
        public List<Npc> Npcs { get; set; }
    }
}
