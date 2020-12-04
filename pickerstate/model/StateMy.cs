using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pickerstate.model
{
    public class StateMy
    {
        public ObservableCollection<State> state { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public ObservableCollection<string> postcode { get; set; }
    }

    public class State
    {
        public string name { get; set; }
        public ObservableCollection<City> city { get; set; }
    }
}
