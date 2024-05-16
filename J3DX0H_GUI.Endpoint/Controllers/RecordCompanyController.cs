using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace J3DX0H_GUI.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordCompanyController : ControllerBase
    {
        IRecordCompanyLogic rlogic;

        public RecordCompanyController(IRecordCompanyLogic rlogic)
        {
            this.rlogic = rlogic;
        }
        // GET
        [HttpGet]
        public IEnumerable<RecordCompany> ReadAll()
        {
            return rlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public RecordCompany Read(int id)
        {
            return rlogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] RecordCompany rcompany)
        {
            this.rlogic.Create(rcompany);
        }

        [HttpPut]
        public void Update([FromBody] RecordCompany rcompany)
        {
            this.rlogic.Update(rcompany);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.rlogic.Delete(id);
        }
    }
}
