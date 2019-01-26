using System;
using System.Collections.Generic;
using System.Text;
using Windows.System.Display;

namespace EngineUwp
{
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
