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
    public class RecordCompanyLogic : IRecordCompanyLogic
    {
        IRepository<RecordCompany> repo;

        public RecordCompanyLogic(IRepository<RecordCompany> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<RecordCompany> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public RecordCompany Read(int id)
        {
            var band = this.repo.Read(id);
            if (band == null)
            {
                throw new ArgumentException("No such Band exist.");
            }
            else
            {
                return band;
            }

        }

        public void Update(RecordCompany band)
        {
            this.repo.Update(band);
        }

        public void Create(RecordCompany band)
        {
            if (band == null)
            {
                throw new ArgumentNullException($"Entity {band} does not contain any values, is null.");
            }
            if (string.IsNullOrEmpty(band.Name))
            {
                throw new ArgumentException("Band must have a name.");
            }
            else
            {
                var bandName = this.repo.ReadAll().FirstOrDefault(x => x.Name == band.Name);
                if (bandName == null)
                {
                    this.repo.Create(band);
                }
                else
                {
                    throw new ArgumentException($"{band.Name} already exists as record.");
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
