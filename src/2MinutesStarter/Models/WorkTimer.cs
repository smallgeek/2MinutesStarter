using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoMinutesStarter.Models
{
    public class WorkTimer : BindableBase
    {
        private DateTimeOffset startTime;

        private TimeSpan elapsedTime;
        public TimeSpan ElapsedTime
        {
            get => elapsedTime;
            set => SetProperty(ref elapsedTime, value);
        }

        private IDisposable? interval;

        public void Start()
        {
            startTime = DateTimeOffset.Now;

            interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => ElapsedTime = DateTimeOffset.Now - startTime);
        }

        public void Stop()
        {
            interval?.Dispose();
        }

    }
}
