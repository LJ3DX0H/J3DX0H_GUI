using J3DX0H_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.Logic.Interfaces
{
    public interface IBandLogic
    {
        void Create(Band band);
        Band Read(int id);
        void Update(Band band);
        void Delete(int id);
        IEnumerable<Band> ReadAll();
    }
}
