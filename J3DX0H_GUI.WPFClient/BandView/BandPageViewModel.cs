using J3DX0H_GUI.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace J3DX0H_GUI.WPFClient.BandView
{
    public class BandPageViewModel : ObservableRecipient
    {
        public RestCollection<Band> Bands { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BandPageViewModel()
        {
            if (!IsInDesignMode)
            {

                Bands = new RestCollection<Band>("http://localhost:4237/", "band");


            }
        }
    }
}
