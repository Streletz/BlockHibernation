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
        private Config _config;
        /// <summary>
        /// Таймер сброса таймеров спящего режима.
        /// </summary>
        private DispatcherTimer timer;
        public HomePage()
        {
            this.InitializeComponent();
            ReadStartConfig();


        }
        /// <summary>
        /// Инициализация конфигурации.
        /// </summary>
        private async void ReadStartConfig()
        {
            _config = await Config.GetInstanceAsync();
            noHibernationCheckBox.IsChecked = _config.PcDontSleep;
            noMonitorOffCheckBox.IsChecked = _config.MonitorDontSleep;
            noMonitorOffCheckBox.IsEnabled = _config.PcDontSleep;
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
            _config.PcDontSleep = (bool)noHibernationCheckBox.IsChecked;
            noMonitorOffCheckBox.IsEnabled = _config.PcDontSleep;
        }
        /// <summary>
        /// Режим работы таймера спящего режима.
        /// </summary>
        private void SetIdleTimerMode()
        {
            if (!_config.PcDontSleep && (bool)noMonitorOffCheckBox.IsChecked)
            {
                noMonitorOffCheckBox.IsChecked = false;
            }
            if (_config.PcDontSleep && !_config.MonitorDontSleep)
            {
                IdleTimerManager.PcDontSleep();
            }
            else if (_config.PcDontSleep && _config.MonitorDontSleep)
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
            _config.MonitorDontSleep = (bool)noMonitorOffCheckBox.IsChecked;
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
