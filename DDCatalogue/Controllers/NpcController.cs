﻿using DDCatalogue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DDCatalogue.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NpcController : ControllerBase
    {

        private readonly ILogger<NpcController> _logger;

        public NpcController(ILogger<NpcController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            using DDContext db = new DDContext();
            return JsonConvert.SerializeObject(db.Npcs
                                                .Include(n => n.Monster)
                                                .Include(n => n.Building)
                                                .Include(n => n.Locale)
                                                .ToList(),
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            using DDContext db = new DDContext();
            return JsonConvert.SerializeObject(db.Npcs.Where(n => n.Id.Equals(id))
                                                .Include(n => n.Monster)
                                                .Include(n => n.Building)
                                                .Include(n => n.Locale)
                                                .ToList()[0],
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        [HttpGet("[action]")]
        public ActionResult<string> Table()
        {
            using DDContext db = new DDContext();
            JArray headers = new JArray(new string[] { "ID", "Name", "Monster", "Location" });
            JArray data = JArray.FromObject(db.Npcs.Include(n => n.Monster)
                                     .Include(n => n.Building)
                                     .Include(n => n.Locale)
                                     .Select(n => new { id = n.Id, npcName = n.Name, monsterName = n.Monster.Name, location = n.Building.Name != null ? $"{n.Building.Name} in {n.Locale.Name}" : n.Locale.Name  })
                                     .ToList(),
                                     JsonSerializer.Create(new JsonSerializerSettings
                                     {
                                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                     }));
            return new JObject()
            {
                ["headers"] = headers,
                ["data"] = data
            }.ToString();
        }

        //[HttpGet("[action]")]
        //public ActionResult<List<Tuple<string, int>>> GetEnum(string property)
        //{
        //        Type type = Type.GetType($"DDCatalogue.Model.{fileDetails.Item1}.{fileDetails.Item2}");
        //}
    }
}
 