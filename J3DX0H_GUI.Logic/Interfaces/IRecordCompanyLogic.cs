using J3DX0H_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Interfaces
{
    public interface IRecordCompanyLogic
    {
        void Create(RecordCompany recordCompany);
        RecordCompany Read(int id);
        void Update(RecordCompany recordCompany);
        void Delete(int id);
        IEnumerable<RecordCompany> ReadAll();

    }
}
