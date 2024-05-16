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
    public class BandRepository : Repository<Band>, IRepository<Band>
    {
        public BandRepository(AlbumDbContext ctx) : base(ctx)
        {

        }

        public override Band Read(int id)
        {
            var b = ctx.Bands.FirstOrDefault(b => b.Id == id);
            if (b != null)
            {
                return b;
            }

            throw new Exception("No Band with such an id exists!");
        }

        public override void Update(Band entity)
        {
            //Doest not work with swagger as one object is Castle.Proxy
            /*
            var bandToupdate = Read(entity.Id);
            foreach (var prop in bandToupdate.GetType().GetProperties())
            {
                prop.SetValue(bandToupdate, prop.GetValue(entity));
            }*/

            var oldBand = Read(entity.Id);

            //Id should not be change  this way.
            //oldBand.Id = entity.Id;
            oldBand.Name = entity.Name;
            oldBand.TimeOfFoundation = entity.TimeOfFoundation;
            oldBand.StillActive = entity.StillActive;
            oldBand.CountryOfFoundation = entity.CountryOfFoundation;
            oldBand.TownOfOrigin = entity.TownOfOrigin;

            ctx.SaveChanges();
        }

    }
}
