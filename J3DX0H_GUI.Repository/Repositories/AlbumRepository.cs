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
    public class AlbumRepository : Repository<Album>, IRepository<Album>
    {
        public AlbumRepository(AlbumDbContext ctx) : base(ctx)
        {

        }

        public override Album Read(int id)
        {


            var a = ctx.Albums.FirstOrDefault(
                b => b.Id == id
                );

            if (a != null)
                return ctx.Albums.FirstOrDefault(t => t.Id == id);

            throw new Exception("No Album with such an id exists.");
        }

        public override void Update(Album entity)
        {
            //Doest not work with swagger as one object is Castle.Proxy
            /*
            var albumToUpdate = Read(entity.Id);
            foreach (var prop in albumToUpdate.GetType().GetProperties())
            {
                prop.SetValue(albumToUpdate, prop.GetValue(entity));
            }*/
            var oldAlbum = Read(entity.Id);
            //Id should not be change  this way.
            //oldAlbum.Id = entity.Id;
            oldAlbum.RecordCompanyId = entity.RecordCompanyId;
            oldAlbum.BandId = entity.BandId;
            oldAlbum.AlbumTitle = entity.AlbumTitle;
            oldAlbum.YearOfPublishing = entity.YearOfPublishing;
            oldAlbum.AlbumLength = entity.AlbumLength;
            oldAlbum.NumberOfTracks = entity.NumberOfTracks;
            oldAlbum.CopiesSold = entity.CopiesSold;


            ctx.SaveChanges();
        }
    }
}
