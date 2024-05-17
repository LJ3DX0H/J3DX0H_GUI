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
    public class AlbumViewModel : ObservableObject
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Album> Albums { get; set; }

        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumTitle = value.AlbumTitle,
                        Id = value.Id
                    };
                }

                OnPropertyChanged();
                (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }




        public ICommand CreateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand UpdateAlbumCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumViewModel()
        {
            if (!IsInDesignMode)
            {


                Albums = new RestCollection<Album>("http://localhost:4237/", "album", "hub");

                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album
                    {
                        AlbumTitle = SelectedAlbum.AlbumTitle
                    });
                });



                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Albums.Update(SelectedAlbum);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });


                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.Id);
                },
                () =>
                {
                    return SelectedAlbum != null;
                }
                );
                SelectedAlbum = new Album();
            }
        }
    }
}
