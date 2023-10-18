using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Post([FromBody] TutorialRequest request)
        {
           // TutorialDomain tutorialDomain = new TutorialDomain();
           // mapeo  Obje API > Obj data

     
           
           if (ModelState.IsValid)
           {
               Tutorial tutorial = new Tutorial()
               {
                   Title = request.Title,
                   Author = request.Author,
                   Year = request.Year,
                   CategoryId = request.CategoryId
               };
               
               return Ok( _tutorialDomain.Create(tutorial));
           }
           else
           {
               return BadRequest();
           }
           
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] TutorialRequest request)
        {
            Tutorial tutorial = new Tutorial()
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
                CategoryId = request.CategoryId
            };
           
           
            return _tutorialDomain.Update(tutorial,id);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _tutorialDomain.Delete(id);
        }
    }
}
