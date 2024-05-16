using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace J3DX0H_GUI.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MerchandiseController : ControllerBase
    {
        IMerchandiseLogic mlogic;

        public MerchandiseController(IMerchandiseLogic rlogic)
        {
            this.mlogic = rlogic;
        }
        // GET
        [HttpGet]
        public IEnumerable<Merchandise> ReadAll()
        {
            return mlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Merchandise Read(int id)
        {
            return this.mlogic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Merchandise item)
        {
            this.mlogic.Create(item);
        }

        [HttpPut]
        public void Update([FromBody] Merchandise item)
        {
            this.mlogic.Update(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.mlogic.Delete(id);
        }
    }
}
