//using cleardrive.shared.Models;
using cleardrive.desktop.viewmodel.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using desktop.cleardrive.desktop.services;
using Microsoft.Maui.Devices.Sensors;
using Models;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace cleardrive.desktop.viewmodel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly IClearDriveDesktopService? _clearDriveDesktopService;

        [ObservableProperty]
        private ObservableCollection<Position> _locations = new();

        [ObservableProperty]
        private Position _selectedLocation;

        public MainViewModel()
        {
            SelectedLocation = new Position();
        }

        public MainViewModel(IClearDriveDesktopService? clearDriveDesktopService)
        {
            SelectedLocation = new Position();
            _clearDriveDesktopService = clearDriveDesktopService;

        }

        [RelayCommand]
        public async Task DoSave(Position newPosition)
        {
            if (_clearDriveDesktopService is not null)
            {
                string result = "";
                if (!newPosition.HasId)
                    result = await _clearDriveDesktopService.InsertAsync(newPosition);

                if (result.Length == 0)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedLocation = new Position();
        }

        [RelayCommand]
        public async Task DoRemove(Position position)
        {
            if (_clearDriveDesktopService is not null)
            {
                string result = await _clearDriveDesktopService.DeleteAsync(position.Id);
                if (result.Length == 0)
                {
                    await UpdateView();
                }
            }
        }

        /*public void AddLocation(Location temp)
        {
            _locations.Add(LocationToPositionConverter(temp));
        }*/

        /*public Position LocationToPositionConverter(Location temp) 
        {
            Position _temp_max = new Position(new Location(0,0));
            _temp_max.LocationINPC = temp;
           return _temp_max;
        }*/

        public override async Task InitializeAsync()
        {
            await UpdateView();
        }

        private async Task UpdateView()
        {
            if (_clearDriveDesktopService is not null)
            {
                List<Position> positions = await _clearDriveDesktopService.SelectAll();
                Locations = new ObservableCollection<Position>(positions);
            }
        }

        /*public Pin CreatePin(Location temp)
        {
            return new Pin
            {
                Location = temp,
                Label = temp.Timestamp.Year.ToString() + "." + temp.Timestamp.Month.ToString() + "." + temp.Timestamp.Day.ToString() + "  " + temp.Timestamp.Hour.ToString() + ":" + temp.Timestamp.Minute.ToString() + ":" + temp.Timestamp.Second.ToString(),
                Address = ((float)temp.Longitude).ToString() + ", " + ((float)temp.Latitude).ToString(),
                Type = PinType.SavedPin
            };
        }*/

        /*public void RemoveLocation(Position temp)
        {
            if (_locations.Any())
            {
                _locations.Remove(temp);
            }
        }*/
    }
}
