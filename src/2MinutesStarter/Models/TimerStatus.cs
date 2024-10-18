namespace TwoMinutesStarter.Models
{
    /// <summary>
    /// タイマーの状態
    /// </summary>
    public enum TimerStatus
    {
        /// <summary>
        /// 初期
        /// </summary>
        Initial,

        /// <summary>
        /// 作業中
        /// </summary>
        Working,

        /// <summary>
        /// 継続確認
        /// </summary>
        ContinueConfirm
    }
}
