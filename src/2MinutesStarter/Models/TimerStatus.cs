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
        /// お試し
        /// </summary>
        Trying,

        /// <summary>
        /// 継続確認
        /// </summary>
        ContinueConfirm
    }
}
