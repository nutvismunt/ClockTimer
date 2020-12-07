using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace ClockTimer
{
    public partial class MainPage : ContentPage
    {
        Button timerButton;
        bool alive = true;
        public MainPage()
        {
            InitializeComponent();
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

                });
                return true;
            });


        }

        private async void OnTimer(object sender, EventArgs e)
        {
            var timer = new Timer();
            await Navigation.PushAsync(timer);
        }
        private async void DisplayTime()
        {
            while (alive)
            {
                Ctimer.Text = DateTime.Now.ToString("HH:mm:ss");
                await Task.Delay(1000);
            }
        }

        public void StartTimer()
        {
            if (alive == true)
            {
                alive = false;
            }
            else
            {
                alive = true;
                DisplayTime();
            }
        }

    }
}
