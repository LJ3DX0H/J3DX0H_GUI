using J3DX0H_GUI.Models;
using J3DX0H_GUI.Repository.Database;
using J3DX0H_GUI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Repository.Repositories
{
    public class RecordCompanyRepository : Repository<RecordCompany>, IRepository<RecordCompany>
    {
        public RecordCompanyRepository(AlbumDbContext ctx) : base(ctx)
        {

        }


        public override RecordCompany Read(int id)
        {
            var m = ctx.RecordCompanys.FirstOrDefault(x => x.Id == id);

            if (m != null)
            {
                return m;
            }

            throw new Exception("No Merchandise with such an ID exists");
        }

        public override void Update(RecordCompany entity)
        {
            //Doest not work with swagger as one object is Castle.Proxy
            /*
            var recordCompanyToUpdate = Read(entity.Id);
            foreach (var prop in recordCompanyToUpdate.GetType().GetProperties())
            {
                prop.SetValue(recordCompanyToUpdate, prop.GetValue(entity));
            }*/

            var oldrC = Read(entity.Id);

            //Id should not be change  this way.
            //oldrC.Id= entity.Id;
            oldrC.Name = entity.Name;
            oldrC.Established = entity.Established;
            oldrC.Country = entity.Country;
            oldrC.City = entity.City;
            oldrC.Founder = entity.Founder;
            oldrC.WebPage = entity.WebPage;

            ctx.SaveChanges();
        }
    }
}
