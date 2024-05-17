using J3DX0H_GUI.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace J3DX0H_GUI.WPFClient
{
    public class BandViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Band> Bands { get; set; }

        private Band selectedBand;

        public Band SelectedBand
        {
            get { return selectedBand; }
            set
            {
                if (value != null)
                {
                    selectedBand = new Band()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                }

                OnPropertyChanged();
                (DeleteBandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateBandCommand { get; set; }

        public ICommand DeleteBandCommand { get; set; }

        public ICommand UpdateBandCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BandViewModel()
        {
            if (!IsInDesignMode)
            {


                Bands = new RestCollection<Band>("http://localhost:4237/", "Band", "hub");

                CreateBandCommand = new RelayCommand(() =>
                {
                    Bands.Add(new Band
                    {
                        Name = SelectedBand.Name
                    });
                });



                UpdateBandCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Bands.Update(SelectedBand);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });


                DeleteBandCommand = new RelayCommand(() =>
                {
                    Bands.Delete(SelectedBand.Id);
                },
                () =>
                {
                    return SelectedBand != null;
                }
                );
                SelectedBand = new Band();
            }
        }
    }
}
