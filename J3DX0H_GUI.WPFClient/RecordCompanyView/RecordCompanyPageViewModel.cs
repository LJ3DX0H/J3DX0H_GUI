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

namespace J3DX0H_GUI.WPFClient.RecordCompanyView
{
    public class RecordCompanyPageViewModel :ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<RecordCompany> RecordCompanies { get; set; }

        private RecordCompany selectedRecordCompany;

        public RecordCompany SelectedRecordCompany
        {
            get { return selectedRecordCompany; }
            set
            {
                if (value != null)
                {
                    selectedRecordCompany = new RecordCompany()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                }

                OnPropertyChanged();
                (DeleteRecordCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateRecordCompanyCommand { get; set; }

        public ICommand DeleteRecordCompanyCommand { get; set; }

        public ICommand UpdateRecordCompanyCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RecordCompanyPageViewModel()
        {
            if (!IsInDesignMode)
            {


                RecordCompanies = new RestCollection<RecordCompany>("http://localhost:4237/", "RecordCompany", "hub");

                CreateRecordCompanyCommand = new RelayCommand(() =>
                {
                    RecordCompanies.Add(new RecordCompany
                    {
                        Name = selectedRecordCompany.Name
                    });
                });



                DeleteRecordCompanyCommand = new RelayCommand(() =>
                {
                    try
                    {
                        RecordCompanies.Update(selectedRecordCompany);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });


                UpdateRecordCompanyCommand = new RelayCommand(() =>
                {
                    RecordCompanies.Delete(selectedRecordCompany.Id);
                },
                () =>
                {
                    return selectedRecordCompany != null;
                }
                );
                selectedRecordCompany = new RecordCompany();
            }
        }
    }
}
