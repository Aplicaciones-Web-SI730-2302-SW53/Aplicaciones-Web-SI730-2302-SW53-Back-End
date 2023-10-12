using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private ITutorialData _tutorialData;
        private ITutorialDomain _tutorialDomain;

        public TutorialController(ITutorialData tutorialData,ITutorialDomain tutorialDomain)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
        }
        
        // GET: api/Tutorial
        [HttpGet]
        public List<Tutorial> Get()
        {
            return _tutorialData.GetAll();
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public Tutorial Get(int id)
        {
           //TutorialSQLData tutorialSqlData = new TutorialSQLData();
           //TutorialOracleData tutorialSqOracleData = new TutorialOracleData();
           // return tutorialSqOracleData.GetById(id);
           return _tutorialData.GetById(id);
        }

        // POST: api/Tutorial
        [HttpPost]
        public bool Post([FromBody] string value)
        {
           // TutorialDomain tutorialDomain = new TutorialDomain();
            return _tutorialDomain.Create(value);
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
