using J3DX0H_GUI.Logic.Services;
using J3DX0H_GUI.Models;
using J3DX0H_GUI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Interfaces
{
    public interface IAlbumLogic
    {
        void Create(Album album);
        Album Read(int id);
        void Update(Album album);
        void Delete(int id);
        IEnumerable<Album> ReadAll();
        IEnumerable<Eredmeny> CopiesSold(IRepository<RecordCompany> rRepo);
        IEnumerable<Eredmeny> CopiesSold2(IRepository<Band> bRepo);
        IEnumerable<Eredmeny2> HasMug(IRepository<Band> bRepo);
        IEnumerable<Eredmeny2> HasTshirtXXL(IRepository<Band> bRepo);
        IEnumerable<Eredmeny> Over500K(IRepository<Band> bRepo);
    }
}
