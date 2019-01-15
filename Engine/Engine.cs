using System;
using System.Runtime.InteropServices;

namespace Engine
{
    /// <summary>
    /// Низкоуровневые функции работы с WinAPI для спящего режима.
    /// </summary>
    public class Engine
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);
        /// <summary>
        /// Управление параметрами спящего режима вручную.
        /// </summary>
        /// <param name="esFlags"></param>
        public static void SetIdleTimerMode(EXECUTION_STATE esFlags)
        {
            SetThreadExecutionState(esFlags);
        }
        /// <summary>
        /// Отключение спящего режима.
        /// </summary>
        public static void PcDontSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
        /// <summary>
        /// Отключение выключения монитора.
        /// </summary>
        public static void MonitorDontSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }
        /// <summary>
        /// Возврат к режиму работы по умолчанию.
        /// </summary>
        public static void RestoreIdleTimerDefaults()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}
