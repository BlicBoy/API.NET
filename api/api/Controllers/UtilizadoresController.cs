using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        // GET: api/Utilizadores
        [HttpGet]
        public IEnumerable<Utilizadores> Get()
        {
            return Utilizadores.GetAllItems();
        }

    //    // GET: api/Utilizadores/5
      [HttpGet("{id}")]
      public Utilizadores Get(string id)
      {
          return Utilizadores.GetItem(id);
      }
      
      
    
    //    // POST: api/Utilizadores
    //
    [HttpPost]
    public string Post([FromBody] Utilizadores utilizador)
    {
        return Utilizadores.CreateUser(utilizador);
    }
    
     // PUT: api/Utilizadores/5
     [HttpPut("{id}")]
     public string Put(string id, [FromBody] Utilizadores utilizador)
     {
         return Utilizadores.UpdateUser(id, utilizador);
     }
    
    //    // DELETE: api/Utilizadores/5
     [HttpDelete("{id}")]
     public string Delete(string id)
     {
         return Utilizadores.Delete(id);
     }
    
    
    }
}
