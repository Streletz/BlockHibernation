using Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlockHibernation
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        /// <summary>
        /// Таймер сброса таймеров спящего режима.
        /// </summary>
        private DispatcherTimer timer;
        public HomePage()
        {
            this.InitializeComponent();
            noHibernationCheckBox.IsChecked = Config.GetInstance().PcDontSleep;
            noMonitorOffCheckBox.IsChecked = Config.GetInstance().MonitorDontSleep;
            noMonitorOffCheckBox.IsEnabled = Config.GetInstance().PcDontSleep;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += TimerTick;
            timer.Start();
            
        }
        /// <summary>
        /// Включение/отключение спящего режима.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoHibernationCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Config.GetInstance().PcDontSleep = (bool)noHibernationCheckBox.IsChecked;
            noMonitorOffCheckBox.IsEnabled = Config.GetInstance().PcDontSleep;            
        }
        /// <summary>
        /// Режим работы таймера спящего режима.
        /// </summary>
        private void SetIdleTimerMode()
        {
            if (!Config.GetInstance().PcDontSleep && (bool)noMonitorOffCheckBox.IsChecked)
            {
                noMonitorOffCheckBox.IsChecked = false;
            }
            if (Config.GetInstance().PcDontSleep && !Config.GetInstance().MonitorDontSleep)
            {
                IdleTimerManager.PcDontSleep();
            }
            else if (Config.GetInstance().PcDontSleep && Config.GetInstance().MonitorDontSleep)
            {
                IdleTimerManager.PcAndMonitorDontSleep();
            }
            else
            {
                IdleTimerManager.RestoreIdleTimerDefaults();
            }
        }

        /// <summary>
        /// Включение/откючение выключения монитора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoMonitorOffCheckBox_Click(object sender, RoutedEventArgs e)
        {
            Config.GetInstance().MonitorDontSleep = (bool)noMonitorOffCheckBox.IsChecked;
        }
        /// <summary>
        /// Обработка таймера сброса таймеров спящего режима.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, object e)
        {
            SetIdleTimerMode();
        }
    }
}
