using System;
using System.Collections.Generic;
using System.Text;
using Windows.System.Display;

namespace EngineUwp
{
    /// <summary>
    /// Работа с таймером спящего режима для UWP.
    /// Большая часть методов суть "заглушки" на случай, если в будущем удастся достичь
    /// функциональности аналогичной импорту SetThreadExecutionState из kernel32.dll (под UWP он недоступен).
    /// Если нет, код этого и базового класса планируется оптимизировать.
    /// </summary>
    public class IdleTimerManagerUwp : IdleTimerManager
    {
        private DisplayRequest _displayRequest;
        public IdleTimerManagerUwp()
        {
            _displayRequest = new DisplayRequest();
        }
        public override void MonitorDontSleep()
        {
            _displayRequest.RequestActive();
        }

        public override void PcAndMonitorDontSleep()
        {
            _displayRequest.RequestActive();
        }

        public override void PcDontSleep()
        {
            _displayRequest.RequestActive();
        }

        public override void RestoreIdleTimerDefaults()
        {
            _displayRequest.RequestRelease();
        }
    }
}
