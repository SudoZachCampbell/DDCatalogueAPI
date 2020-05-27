﻿using DDCatalogue.Model.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDCatalogue.Model.Attributes
{
    public class Trait : IAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<CreatureTrait> Creatures { get; set; }
    }
}