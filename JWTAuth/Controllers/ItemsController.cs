using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuth.Controllers
{
    
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        [ActionName("availableitems")]
         public IActionResult Get()
        {

            return Ok();
        }

        [ActionName("availableterms")]
        public IActionResult Get(int id)
        {

            return Ok();
        }
    }
}
