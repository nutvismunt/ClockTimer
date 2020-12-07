
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace ClockTimer
{
    public partial class MainPage : ContentPage
    {
        object container;

        public MainPage()
        {
            InitializeComponent();
            Ctimer.Text = "Таймер";
            SetTimer();
        }

        private async void SetTimer()
        {
            buttonPause.IsVisible = false;
            buttonContinue.IsVisible = false;

            while (true)
            {
                date.Text = DateTime.Now.ToString("dd.MM.yyyy");
                clock.Text = DateTime.Now.ToString("HH:mm:ss");

                if (App.Current.Properties.TryGetValue("isTimer", out container))
                {
                    if (Convert.ToDateTime(container.ToString()).ToString("HH:mm:ss") != "00:00:00")
                    {
                        StartTime();
                        buttonPause.IsVisible = true;
                        buttonContinue.IsVisible = false;
                    }
                    else
                    {
                        buttonPause.IsVisible = false;
                        buttonContinue.IsVisible = false;
                        App.Current.Properties.Remove("isTimer");
                        await DisplayAlert("Таймер", "Таймер дошел до 00:00:00", "Ок");
                        Ctimer.Text = "Таймер";
                    }

                }
                await Task.Delay(1000);
            }


        }


        private void PauseClicked(object sender, EventArgs e)
        {
            if (container == null)
            {
                if (App.Current.Properties.TryGetValue("isTimer", out container))
                {
                    container = App.Current.Properties["isTimer"].ToString();
                }
                if (App.Current.Properties.TryGetValue("isPaused", out container))
                {
                    container = App.Current.Properties["isPaused"].ToString();
                }
            }
            App.Current.Properties.Remove("isTimer");
            App.Current.Properties.Add("isPaused", Convert.ToDateTime(container.ToString()).AddSeconds(-1).ToString("HH:mm:ss"));
            container = App.Current.Properties["isPaused"];
            Ctimer.Text = container.ToString();
            buttonPause.IsVisible = false;
            buttonContinue.IsVisible = true;
        }

        private void ContinueClicked(object sender, EventArgs e)
        {
            if (container == null) {
                if (App.Current.Properties.TryGetValue("isTimer", out container))
                {
                    container = App.Current.Properties["isTimer"].ToString();
                }
                if (App.Current.Properties.TryGetValue("isPaused", out container))
                {
                    container = App.Current.Properties["isPaused"].ToString();
                }
            }
            App.Current.Properties.Add("isTimer", container.ToString());
            App.Current.Properties.Remove("isPaused");
            container = App.Current.Properties["isTimer"];
            Ctimer.Text = container.ToString();
            buttonPause.IsVisible = true;
            buttonContinue.IsVisible = false;
        }

        private async void Ctimer_Clicked(object sender, EventArgs e)
        {
            var timer = new Timer();

            await Navigation.PushAsync(timer);
        }

        private void StartTime()
        {
            var getTime = Convert.ToDateTime(container.ToString());
            getTime = getTime.AddSeconds(-0.5);
            Ctimer.Text = getTime.ToString("HH:mm:ss");
            App.Current.Properties.Remove("isTimer");
            App.Current.Properties.Add("isTimer", getTime);

        }
    }
}