using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClockTimer
{
    public class TimerService
    {
     /*   private CancellationTokenSource cts;
        public void StartUpdate()
        {
            if (cts != null) cts.Cancel();
            cts = new CancellationTokenSource();
            var ignore = UpdaterAsync(cts.Token);
        }

        public void StopUpdate()
        {
            if (cts != null) cts.Cancel();
            cts = null;
        }

        public async Task UpdaterAsync()
        {
            while (!cts.IsCancellationRequested)
            {
                yourTextView.Text = whatever;
                await Task.Delay(100, cts);
            }
        }*/
    }
}
