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
        public Timer()
        {
            InitializeComponent();
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
        }
        private async void StartTimer(object sender, EventArgs e)
        {
            bool returnValue;
            if (startStop.Text == "старт")
            {
                returnValue = true;
                startStop.Text = "стоп";
            }
            else
            {
                startStop.Text = "старт";
                returnValue = false;
            }

          //  StartingTimer(Convert.ToDateTime(timePicker.Time.ToString()).AddSeconds(Convert.ToInt32(seconds.Text)), returnValue);
            var main = new MainPage();
            _time = Convert.ToDateTime(timePicker.Time.ToString()).AddSeconds(Convert.ToInt32(seconds.Text));
          //  main.BindingContext = (_time,false);
            App.Current.Properties.Add("isTimer",_time);
            await Navigation.PopAsync();

        }
      /*  public async void StartingTimer(DateTime time, bool returnValue)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _time = time.AddSeconds(-1);
                });
                return returnValue; // True = Repeat again, False = Stop the timer
            });
        }*/
    }
}