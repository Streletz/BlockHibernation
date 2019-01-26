using System;
using System.Runtime.InteropServices;

namespace Engine
{
    /// <summary>
    /// Низкоуровневые функции работы с WinAPI таймеров спящего режима.
    /// Подробнее см. документацию:  https://docs.microsoft.com/ru-ru/windows/desktop/api/winbase/nf-winbase-setthreadexecutionstate
    /// </summary>
    public class IdleTimerManager
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);
        /// <summary>
        /// Управление сборосом спящего режима вручную.
        /// </summary>
        /// <param name="esFlags"></param>
        public static void SetIdleTimerMode(EXECUTION_STATE esFlags)
        {
            SetThreadExecutionState(esFlags);
        }
        /// <summary>
        /// Сброс таймера спящего режима.
        /// </summary>
        public static void PcDontSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
        /// <summary>
        /// Сброс таймера выключения монитора.
        /// </summary>
        public static void MonitorDontSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }
        /// <summary>
        /// Сброс таймеров перехода в спящий режим системы и монитора одновременно.
        /// </summary>
        public static void PcAndMonitorDontSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }
        /// <summary>
        /// Возврат таймеров к режиму работы по умолчанию.
        /// </summary>
        public static void RestoreIdleTimerDefaults()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
    }
}
