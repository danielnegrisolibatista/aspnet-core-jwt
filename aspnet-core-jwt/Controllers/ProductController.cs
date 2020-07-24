using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_jwt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace aspnet_core_jwt.Controllers
{
    [Authorize]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Product 1", "Product 2", "Product 3", "Product 4"
        };

        
        [HttpGet]
        [Authorize(Roles = "ADMINISTRATOR")]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                ID = index,
                Description = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
