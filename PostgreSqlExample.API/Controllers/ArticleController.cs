using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreSqlExample.API.Request;
using PostgreSqlExample.Data;
using PostgreSqlExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreSqlExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private PostgresqlExampleDbContext _postgresqlExampleDbContext;
        public ArticleController(PostgresqlExampleDbContext postgresqlExampleDbContext)
            => _postgresqlExampleDbContext = postgresqlExampleDbContext;
            
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postgresqlExampleDbContext.Set<Article>().ToList();
            return Ok(result);
        }

        [HttpPost("add")] 
        public IActionResult Add([FromBody]ArticleRequestModel Request)
        {
            var model = new Article
            {
                Title = Request.Title,
                Description = Request.Description

            };
            _postgresqlExampleDbContext.Add(model);
            _postgresqlExampleDbContext.SaveChanges();
            return Ok("başarılı");
        }
      
    }
}
