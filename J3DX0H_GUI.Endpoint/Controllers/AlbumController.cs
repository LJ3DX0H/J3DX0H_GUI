using J3DX0H_GUI.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;




        public AlbumController(IAlbumLogic alogic, IHubContext<SignalRHub> hub)
        {
            this.alogic = alogic;
            this.hub = hub;
        }
        // GET
        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return this.alogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return this.alogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Album item)
        {
            this.alogic.Create(item);
            this.hub.Clients.All.SendAsync("AlbumCreated", item);
        }

        [HttpPut]
        public void Update([FromBody] Album item)
        {
            this.alogic.Update(item);
            this.hub.Clients.All.SendAsync("AlbumUpdated", item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = this.alogic.Read(id);
            this.alogic.Delete(id);
            this.hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
        }
    }
}
