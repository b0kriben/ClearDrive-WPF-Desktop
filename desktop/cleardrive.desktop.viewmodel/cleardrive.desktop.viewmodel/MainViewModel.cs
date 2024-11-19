//using cleardrive.shared.Models;
using System.Collections.ObjectModel;

namespace cleardrive.desktop.viewmodel
{
    public class MainViewModel : ViewModelBase
    {
        private double _elapsedTime;
        private string _designedItem;
        private int _timeCalculation;

        public double ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                _elapsedTime = value;
                OnPropertyChanged();
            }
        }

        public int TimeCalculation
        {
            get { return _timeCalculation; }
            set
            {
                _timeCalculation = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ObstacleList { get; set; }

        public string DesignedItem
        {
            get { return _designedItem; }
            set
            {
                _designedItem = value;
                OnPropertyChanged();
                Calculation();
            }
        }

        public MainViewModel()
        {
            ObstacleList = new ObservableCollection<string>
            {
                "Közúti hibák",
                "Természeti hibák",
                "Egyéb hibák"
            };
            _designedItem = ObstacleList[0];
            Calculation();
        }

        private void Calculation()
        {

            switch (_designedItem)
            {
                case "Közúti hibák":
                    TimeCalculation = 20;
                    break;
                case "Természeti hibák":
                    TimeCalculation = 30;
                    break;
                case "Egyéb hibák":
                    TimeCalculation = 40;
                    break;
            }


            ElapsedTime = 10.5;
        }
    }
}
