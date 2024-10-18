using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TwoMinutesStarter.Models
{
    /// <summary>
    /// 作業タイマー
    /// </summary>
    public class WorkTimer : BindableBase
    {
        private IDisposable? interval;

        private TimeSpan timeLeft;
        /// <summary>
        /// 残り時間
        /// </summary>
        public TimeSpan TimeLeft
        {
            get => timeLeft;
            private set => SetProperty(ref timeLeft, value);
        }

        private TimerStatus status;
        /// <summary>
        /// タイマーの状態
        /// </summary>
        public TimerStatus Status
        {
            get => status;
            private set => SetProperty(ref status, value);
        }

        /// <summary>
        /// タイマーを開始する
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Start()
        {
            if (Status != TimerStatus.Initial)
            {
                throw new InvalidOperationException("開始できるのは初期状態のみです。");
            }

            TimeLeft = new TimeSpan(0, 2, 0);

            // 1秒タイマー
            interval = Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ =>
                {
                    var t = TimeLeft - TimeSpan.FromSeconds(1);
                    TimeLeft = t;

                    if (t.Hours == 0 && t.Minutes == 0 && t.Seconds == 0)
                    {
                        Stop();
                    }
                });

            Status = TimerStatus.Working;
        }

        /// <summary>
        /// タイマーを停止する
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Stop()
        {
            if (Status != TimerStatus.Working)
            {
                throw new InvalidOperationException("停止できるのは作業中のみです。");
            }

            Status = TimerStatus.ContinueConfirm;
            interval?.Dispose();
        }
    }
}
