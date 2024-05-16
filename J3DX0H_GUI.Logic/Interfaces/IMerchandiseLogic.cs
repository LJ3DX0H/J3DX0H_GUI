using J3DX0H_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Interfaces
{
    public interface IMerchandiseLogic
    {
        void Create(Merchandise merchandise);
        Merchandise Read(int id);
        void Update(Merchandise merchandise);
        void Delete(int id);
        IEnumerable<Merchandise> ReadAll();
    }
}
