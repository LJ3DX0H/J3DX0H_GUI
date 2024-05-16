using J3DX0H_GUI.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace J3DX0H_GUI.WPFClient.MerchandiseView
{
    public class MerchandisePageViewModel : ObservableRecipient
    {
        public RestCollection<Merchandise> Merchandises { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MerchandisePageViewModel()
        {
            if (!IsInDesignMode)
            {

                Merchandises = new RestCollection<Merchandise>("http://localhost:4237/", "Merchandise");


            }
        }
    }
}
