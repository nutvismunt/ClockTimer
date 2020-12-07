using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClockTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer : ContentPage
    {
        public DateTime _time;
        public bool isenabled;
        object container;
        public Timer()
        {
            InitializeComponent();
            startStop.Text = "старт";
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(seconds.Text))
                if (Convert.ToInt32(seconds.Text) > 60)
                {
                    string entryText = seconds.Text;
                    seconds.TextChanged -= OnEntryTextChanged;
                    seconds.Text = e.OldTextValue;
                    seconds.TextChanged += OnEntryTextChanged;
                }
            if (string.IsNullOrWhiteSpace(seconds.Text)) seconds.Text = "00";
        }
        private async void StartTimer(object sender, EventArgs e)
        {
            if (App.Current.Properties.TryGetValue("isTimer", out container)) App.Current.Properties.Remove("isTimer");
            if (App.Current.Properties.TryGetValue("isPaused", out container)) App.Current.Properties.Remove("isPaused");
            _time = Convert.ToDateTime(timePicker.Time.ToString()).AddSeconds(Convert.ToInt32(seconds.Text));
            App.Current.Properties.Add("isTimer", _time);
            await Navigation.PopAsync();

        }
    }
}