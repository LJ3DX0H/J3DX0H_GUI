using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.WPFClient
{
    public class RCViaWindow : IRCViaWindowService
    {
        public void Open()
        {
            new RecordCompanyView().ShowDialog();
        }
    }
}
