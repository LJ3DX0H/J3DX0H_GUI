using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3DX0H_GUI.WPFClient
{
    public class MerchViaWindow : IMerchViaWindowService
    {
        public void Open()
        {
            new MerchandiseView().ShowDialog();
        }
    }
}
