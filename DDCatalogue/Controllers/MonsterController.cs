﻿using DDCatalogue.Model;
using DDCatalogue.Model.Creatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonsterController : GenericController<Monster>
    {
        // GET: api/Monster
        [HttpGet]
        public ActionResult<List<Monster>> GetMonsters([FromQuery] string include)
        {
            return UnitOfWork.Repository.Get(includeProperties: include?.Split(',')).ToList();
        }

        // GET: api/Monster/5
        [HttpGet("{id}")]
        public ActionResult<Monster> GetMonsterById(int id, [FromQuery] string include)
        {
            return GetGen(id, include);
        }

        [HttpPatch("{id}")]
        public ActionResult<Monster> PatchMonster(int id, [FromBody] JsonPatchDocument<Monster> patchDoc, [FromQuery] string include)
        {
            return PatchGen(id, patchDoc, include);
        }

        // PUT: api/Monster/5
        [HttpPut("{id}")]
        public IActionResult PutMonster(int id, Monster monster)
        {
            return PutGen(id, monster);
        }

        // POST: api/Monster
        [HttpPost]
        public ActionResult<Monster> PostMonster(Monster monster)
        {
            return PostGen(monster);
        }

        // DELETE: api/Monster/5
        [HttpDelete("{id}")]
        public ActionResult<Monster> DeleteMonster(int id)
        {
            return DeleteGen(id);
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> GetTable()
        {
            dynamic monsters = UnitOfWork.Repository.Get()
                .Select(m => new
                {
                    id = m.Id,
                    name = m.Name,
                    passivePerception = m.PassivePerception,
                    alignment = m.Alignment
                }).ToList();
            return monsters;
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<List<string>> GetEnum(string name)
        {
            return GetEnumGen(name);
        }
    }
}
