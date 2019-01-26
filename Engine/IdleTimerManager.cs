using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    /// <summary>
    /// Базовый класс для управления таймером спящего режима.
    /// </summary>
    public abstract class IdleTimerManager
    {
        /// <summary>
        /// Сброс таймера спящего режима.
        /// </summary>
        public abstract void PcDontSleep();

        /// <summary>
        /// Сброс таймера выключения монитора.
        /// </summary>
        public abstract void MonitorDontSleep();

        /// <summary>
        /// Сброс таймеров перехода в спящий режим системы и монитора одновременно.
        /// </summary>
        public abstract void PcAndMonitorDontSleep();
        
        /// <summary>
        /// Возврат таймеров к режиму работы по умолчанию.
        /// </summary>
        public abstract void RestoreIdleTimerDefaults();
        
    }
}
