using J3DX0H_GUI.Models;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static J3DX0H_GUI.WPFClient.MainWindow.MainWindowViewModel;

namespace J3DX0H_GUI.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

        }

        public class MainWindowViewModel : ViewModelBase
        {
            private object _currentViewModel;

            public RelayCommand NavigateToAlbumCommand { get; }
            public RelayCommand NavigateToBandCommand { get; }
            public RelayCommand NavigateToMerchandiseCommand { get; }
            public RelayCommand NavigateToRecordCompanyCommand { get; }

            public object CurrentViewModel
            {
                get => _currentViewModel;
                set
                {
                    _currentViewModel = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }
            public MainWindowViewModel()
            {
                NavigateToAlbumCommand = new RelayCommand(AlbumView);
                NavigateToBandCommand = new RelayCommand(BandView);
                NavigateToMerchandiseCommand = new RelayCommand(MerchandiseView);
                NavigateToRecordCompanyCommand = new RelayCommand(RecordCompanyView);

            }
            private void AlbumView()
            {
                CurrentViewModel = new AlbumViewModel();
            }

            private void BandView()
            {
                CurrentViewModel = new BandViewModel();
            }

            private void MerchandiseView()
            {
                CurrentViewModel = new MerchandiseViewModel();
            }
            private void RecordCompanyView()
            {
                CurrentViewModel = new RecordCompanyViewModel();
            }
        }



            public class ViewModelBase : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;

                protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }


            public class AlbumViewModel : ViewModelBase { public string Name { get; set; } }
            public class BandViewModel : ViewModelBase { public string Name { get; set; } }
            public class MerchandiseViewModel : ViewModelBase { public string Name { get; set; } }
            public class RecordCompanyViewModel : ViewModelBase { public string Namet { get; set; } }


            public class RelayCommand : ICommand
            {
                public readonly Action<object> _execute;
                public readonly Predicate<object> _canExecute;

                public RelayCommand(Action<object> execute)
              : this(execute, null)
                {
                }

                public RelayCommand(Action<object> execute, Predicate<object> canExecute)
                {
                    if (execute == null)
                        throw new ArgumentNullException("execute");
                    _execute = execute;
                    _canExecute = canExecute;
                }


                public bool CanExecute(object parameter)
                {
                    return _canExecute == null ? true : _canExecute(parameter);
                }

                public event EventHandler CanExecuteChanged
                {
                    add { CommandManager.RequerySuggested += value; }
                    remove { CommandManager.RequerySuggested -= value; }
                }

                public void Execute(object parameter)
                {
                    _execute(parameter);
                }

            }
        
    }
}
