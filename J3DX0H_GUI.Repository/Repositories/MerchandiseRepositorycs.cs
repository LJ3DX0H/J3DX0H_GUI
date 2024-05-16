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
    public class MerchandiseRepository : Repository<Merchandise>, IRepository<Merchandise>
    {
        public MerchandiseRepository(AlbumDbContext ctx) : base(ctx)
        {

        }

        public override Merchandise Read(int id)
        {
            var m = ctx.Merchandises.FirstOrDefault(x => x.Id == id);

            if (m != null)
            {
                return m;
            }

            throw new Exception("No Merchandise with such an ID exists");
        }

        public override void Update(Merchandise entity)
        {
            //Doest not work with swagger as one object is Castle.Proxy
            /*
            var merchToUpdate = Read(entity.Id);
            foreach (var prop in merchToUpdate.GetType().GetProperties())
            {
                prop.SetValue(merchToUpdate, prop.GetValue(entity));
            }*/

            var oldMerch = Read(entity.Id);
            //Id should not be change  this way.
            //oldMerch.Id=entity.Id;
            oldMerch.AlbumId = entity.AlbumId;
            oldMerch.TypeOfMerch = entity.TypeOfMerch;
            oldMerch.SizeOfMerch = entity.SizeOfMerch;
            oldMerch.Price = entity.Price;
            oldMerch.Available = entity.Available;

            ctx.SaveChanges();
        }
    }
}
