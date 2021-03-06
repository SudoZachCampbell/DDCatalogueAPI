﻿using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcController : GenericController<Npc>
    {

        [HttpGet]
        public ActionResult<List<Npc>> Get([FromQuery] string include)
        {
            return GetGen(include);
        }

         
        [HttpGet("{id}")]
        public ActionResult<Npc> Get(int id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Npc> Patch(int id, [FromBody] JsonPatchDocument<Npc> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> Table()
        {
            dynamic npcs = UnitOfWork.Repository.Get()
                .Select(n => new
                {
                    id = n.Id,
                    name = n.Name,
                    monsterName = n.Monster.Name,
                    location = n.Building.Name != null ? $"{n.Building.Name} in {n.Locale.Name}" : n.Locale.Name
                }).ToList();
            return npcs;
        }
    }
}
