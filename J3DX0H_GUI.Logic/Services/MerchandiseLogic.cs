using J3DX0H_GUI.Logic.Interfaces;
using J3DX0H_GUI.Models;
using J3DX0H_GUI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Services
{
    public class MerchandiseLogic : IMerchandiseLogic
    {
        //create, update might affect another table.
        IRepository<Merchandise> repo;

        public MerchandiseLogic(IRepository<Merchandise> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Merchandise> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public Merchandise Read(int id)
        {
            var band = this.repo.Read(id);
            if (band == null)
            {
                throw new ArgumentException("No such Merchandise exist.");
            }
            else
            {
                return band;
            }

        }

        public void Update(Merchandise band)
        {
            this.repo.Update(band);
        }

        public void Create(Merchandise band)
        {
            if (band == null)
            {
                throw new ArgumentNullException($"Entity {band} does not contain any values, is null.");
            }
            if (string.IsNullOrEmpty(band.MerchName))
            {
                throw new ArgumentException("Band must have a name.");
            }
            else
            {
                var bandName = this.repo.ReadAll().FirstOrDefault(x => x.MerchName == band.MerchName);
                if (bandName == null)
                {
                    this.repo.Create(band);

                }
                else
                {
                    throw new ArgumentException($"{band.MerchName} already exists as record.");
                }
            }
        }
        public void Delete(int id)
        {
            var band = this.repo.Read(id);
            if (band == null)
            {
                throw new ArgumentException($"No such band exists, delete cannot be performed.");
            }
            else
            {
                this.repo.Delete(id);
            }

        }



    }
}
