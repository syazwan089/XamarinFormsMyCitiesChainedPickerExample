using pickerstate.model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System;

namespace pickerstate
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private StateMy myState;

        public StateMy MyState
        {
            get { return myState; }
            set { myState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyState"));
            }
        }

        private State selectedState;

        public State SeletedState
        {
            get { return selectedState; }
            set { selectedState = value;
            if(SeletedState != null)
                {
                    Cities = SeletedState.city;
                }
            
            }
        }


        private ObservableCollection<City> cities;

        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set { cities = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cities"));
            }
        }


        public Command selectedIte { get; set; }


        public MainViewModel()
        {
            MyState = new StateMy();
            readJson();
          
        }

       

        private async void readJson()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("pickerstate.model.jso.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var json =  JsonConvert.DeserializeObject<StateMy>(text);

            MyState =  json;
        }
    }
}
