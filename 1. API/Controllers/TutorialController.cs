using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1._API.Request;
using _1._API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using AutoMapper;
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
        private IMapper _mapper;
        public TutorialController(ITutorialData tutorialData,ITutorialDomain tutorialDomain,IMapper mapper)
        {
            _tutorialData = tutorialData;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
        }
        
        // GET: api/Tutorial
        /// <summary>
        /// Get all tutorials without any filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<TutorialResponse>> GetAsync()
        {
            var tutorials= await _tutorialData.GetAllAsync();
             
             var response = _mapper.Map<List<Tutorial>, List<TutorialResponse>>(tutorials);

             return response;
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
        /// <response code="200">Returns the newly created tutorial</response>
        /// <response code="400">If the tutorial is null </response>
        /// <response code="500">Unexcpeted error , maybe database is down </response>
        [HttpPost]
        /// <response code="20">Returns the newly created tutorial</response>
        /// <response code="400">If the tutotial is null or fields required ar empty</response>
        /// <response code="500">If the tutotial is null or fields required ar empty</response>

        public IActionResult Post([FromBody] TutorialRequest request)
        {
           // TutorialDomain tutorialDomain = new TutorialDomain();
           // mapeo  Obje API > Obj data

           try
           {
               if (ModelState.IsValid)
               {
                   /* Tutorial tutorial = new Tutorial()
                    {
                        Title = request.Title,
                        Author = request.Author,
                        Year = request.Year,
                        CategoryId = request.CategoryId
                    };*/

                   var tutorial = _mapper.Map<TutorialRequest, Tutorial>(request);

                   return Ok(_tutorialDomain.Create(tutorial));
                   //return Created("/post",_tutorialDomain.Create(tutorial));
               }
               else
               {
                   return BadRequest();
               }
           }
           catch (Exception e)
           {
               return StatusCode(500);
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
