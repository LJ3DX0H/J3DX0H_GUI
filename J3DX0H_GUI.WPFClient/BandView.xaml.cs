﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace J3DX0H_GUI.WPFClient
{
    /// <summary>
    /// Interaction logic for BandView.xaml
    /// </summary>
    public partial class BandView : Window
    {
        public BandView()
        {
            
            BandViewModel bV = new BandViewModel();
            this.DataContext = bV;
        }

        private void bV_EditedDone(object sender, EventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
