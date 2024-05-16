using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace J3DX0H_GUI.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        IBandLogic blogic;

        public BandController(IBandLogic blogic)
        {
            this.blogic = blogic;
        }
        // GET
        [HttpGet]
        public IEnumerable<Band> ReadAll()
        {
            return this.blogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Band Read(int id)
        {
            return this.blogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Band item)
        {
            this.blogic.Create(item);
        }

        [HttpPut]
        public void Update([FromBody] Band item)
        {
            this.blogic.Update(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.blogic.Delete(id);
        }
    }
}
