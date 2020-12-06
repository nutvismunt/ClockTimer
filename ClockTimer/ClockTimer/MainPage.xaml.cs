using System;
using System.Threading;
using System.Timers;
using Xamarin.Forms;

namespace ClockTimer
{
    public partial class MainPage : ContentPage
    {
        object container;
        string timeLeft;
        public MainPage()
        {
            InitializeComponent();

         //   if (App.Current.Properties.TryGetValue("isTimer", out container))
         //   {
           //     timeLeft = Convert.ToDateTime(App.Current.Properties["isTimer"].ToString()).ToString("HH:mm:ss");
          //  }


            SetTimer();
        }

        private void SetTimer()
        {    
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    date.Text = DateTime.Now.ToString("dd.MM.yyyy");
                    clock.Text = DateTime.Now.ToString("HH:mm:ss");
                  //  Ctimer.Text = !string.IsNullOrWhiteSpace(timeLeft)? Convert.ToDateTime(timeLeft).AddSeconds(-1).ToString("HH:mm:ss") : "Таймер";
                 //   var form = Convert.ToDateTime(container.ToString());
                 //  var time = form.AddSeconds(-1).ToString("HH:mm:ss");
                    /*  if (App.Current.Properties.TryGetValue("isTimer", out container))
                      {
                          clock_Timer();
                      }
                      else Ctimer.Text = "Таймер";*/
                });
                return true;
            });


        }

        private async void OnTimer(object sender, EventArgs e)
        {
            var timer = new Timer();
            await Navigation.PushAsync(timer);
        }


        private void clock_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (App.Current.Properties.TryGetValue("isTimer", out container))
            {


                        if (container != null && container.ToString() != "00:00:00")
                        {
                           var b = Convert.ToDateTime(container.ToString()).AddSeconds(-1).ToString("HH:mm:ss");
                            Ctimer.Text = b;
                            App.Current.Properties.Remove("isTimer");
                            App.Current.Properties.Add("isTimer", b);
                            container = App.Current.Properties["isTimer"];
                        }
                        else if (container.ToString() == "00:00:00")
                        {
                            App.Current.Properties.Remove("isTimer");
                            DisplayAlert("Таймер", "Таймер достиг 00:00:00", "ОК");
                        }
                        else Ctimer.Text = "Таймер";
            }
        }
    }
}
