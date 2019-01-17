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

namespace BlockHibernation
{
    /// <summary>
    /// Дочерняя страница "О программе".
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Ссыдка на сайт разработчика.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var uriBing = new Uri(@"http://streletzcoder.ru");            
            var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);
        }
    }
}
