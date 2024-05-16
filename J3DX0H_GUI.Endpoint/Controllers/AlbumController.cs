using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace J3DX0H_GUI.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic alogic;

        public AlbumController(IAlbumLogic alogic)
        {
            this.alogic = alogic;

        }

        // GET: api/<AlbumController>
        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return this.alogic.ReadAll();
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return this.alogic.Read(id);
        }

        // POST api/<AlbumController>
        [HttpPost]
        public void Create([FromBody] Album item)
        {
            this.alogic.Create(item);
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Album item)
        {
            this.alogic.Update(item);
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.alogic.Delete(id);
        }
    }
}
