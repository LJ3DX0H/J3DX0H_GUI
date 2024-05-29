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
    public class MerchandiseViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Merchandise> Merchandises { get; set; }

        private Merchandise selectedMerchandise;

        public Merchandise SelectedMerchandise
        {
            get { return selectedMerchandise; }
            set
            {
                if (value != null)
                {
                    selectedMerchandise = new Merchandise()
                    {
                        MerchName = value.MerchName,
                        Id = value.Id
                    };
                }

                OnPropertyChanged();
                (DeleteMerchandiseCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }




        public ICommand CreateMerchandiseCommand { get; set; }

        public ICommand DeleteMerchandiseCommand { get; set; }

        public ICommand UpdateMerchandiseCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MerchandiseViewModel()
        {
            if (!IsInDesignMode)
            {


                Merchandises = new RestCollection<Merchandise>("http://localhost:62997/", "Merchandise", "hub");

                CreateMerchandiseCommand = new RelayCommand(() =>
                {
                    Merchandises.Add(new Merchandise
                    {
                        MerchName = selectedMerchandise.MerchName
                    });
                });



                UpdateMerchandiseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Merchandises.Update(SelectedMerchandise);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });


                DeleteMerchandiseCommand = new RelayCommand(() =>
                {
                    Merchandises.Delete(SelectedMerchandise.Id);
                },
                () =>
                {
                    return SelectedMerchandise != null;
                }
                );
                SelectedMerchandise = new Merchandise();
            }
        }
    }
}
