using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkService.Helpers;
using NetworkService.Models;

namespace NetworkService.ViewModel
{
    public class MeasurementGraphViewModel : BindableBase
    {
        #region IZABRANI REAKTOR
        private Reaktor selectedDevice;
        public Reaktor SelectedDevice
        {
            get { return selectedDevice; }
            set
            {
                if (selectedDevice != value)
                {
                    selectedDevice = value;
                    OnPropertyChanged("SelectedDevice");
                }
            }
        }
        #endregion

        #region KONSTRUKTOR
        public MeasurementGraphViewModel()
        {
            GraphMeasuringDevices = NetworkEntitiesViewModel.SviReaktori;
            Dates = new ObservableCollection<TimeSpan>();
            Values = new ObservableCollection<double>();

            WarningVisability = new ObservableCollection<string>()
            {
                "Hidden",
                "Hidden",
                "Hidden",
                "Hidden",
                "Hidden"
            };

            Strokes = new ObservableCollection<string>()
            {
                "Blue",
                "Blue",
                "Blue",
                "Blue",
                "Blue"
            };

            Fills = new ObservableCollection<string>()
            {
                "Aqua",
                "Aqua",
                "Aqua",
                "Aqua",
                "Aqua"
            };

            ShowGraphCommand = new MyICommand(ShowGraph);
        }
        #endregion

        #region PROPERTIJI
        public ObservableCollection<TimeSpan> Dates { get; set; }
        public ObservableCollection<double> Values { get; set; }
        public ObservableCollection<string> Strokes { get; set; }
        public ObservableCollection<string> Fills { get; set; }
        public ObservableCollection<string> WarningVisability { get; set; }
        public ObservableCollection<Reaktor> GraphMeasuringDevices { get; set; }
        public MyICommand ShowGraphCommand { get; set; }  
        #endregion

        #region METODE
        private void ShowGraph()
        {
            List<string> lines = new List<string>();
            Dates.Clear();
            Values.Clear();
            HideAllWarnings();

            int j = 0;
            string text = "";
            FileStream fs = new FileStream("../../Log.txt", FileMode.Open, FileAccess.Read);

            using (StreamReader sr = new StreamReader(fs))
            {
                while ((text = sr.ReadLine()) != null)
                {
                    lines.Add(text);
                }
                lines.Reverse();

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] split = lines[i].Split(',');
                    if (Int32.Parse(split[1]) == SelectedDevice.Id)
                    {
                        if (j == 5)
                        {
                            break;
                        }
                        else
                        {
                            j++;
                            TimeSpan date = DateTime.Parse(split[0]).TimeOfDay;
                            Dates.Add(date);
                            double value = double.Parse(split[2]);
                            Values.Add(value);
                        }
                    }
                }
            }

            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i] > 350 || Values[i] < 250)
                {
                    //Values[i] = 0;
                    WarningVisability[i] = "Visible";
                    Strokes[i] = "Red";
                    Fills[i] = "HotPink";
                }
            }
        }

        private void HideAllWarnings()
        {
            for (int i = 0; i < WarningVisability.Count; i++)
            {
                if (WarningVisability[i].Equals("Visible"))
                {
                    WarningVisability[i] = "Hidden";
                    Strokes[i] = "Blue";
                    Fills[i] = "Aqua";
                }
            }
        }
        #endregion
    }
}
