using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace BlockHibernation
{
    /// <summary>
    /// Кофигурация приложения.
    /// </summary>
    [Serializable]
    public class Config
    {
        private static Config _instance;

        private Config() { }
        public static async Task<Config> GetInstanceAsync()
        {
            if (_instance == null)
            {
                // Иницализация сохранённых настроек.
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Config));
                    StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("config.xml");
                    using (var fs = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        _instance = (Config)serializer.Deserialize(fs.AsStreamForRead());
                    }
                }
                catch
                {
                    // Инициализация с параметрами по умолчанию.
                    _instance = new Config();
                }
            }
            return _instance;
        }
        /// <summary>
        /// Включение запрета перевода в спящий режим.
        /// </summary>
        public bool PcDontSleep { get; set; } = true;
        /// <summary>
        /// Включение запрета на отключение монитора.
        /// </summary>
        public bool MonitorDontSleep { get; set; } = false;
        /// <summary>
        /// Сохранение кофигурации приложения.
        /// </summary>
        public async void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            StorageFile file = null;
            try
            {
                file = await ApplicationData.Current.LocalFolder.GetFileAsync("config.xml");
            }
            catch (FileNotFoundException ex)
            {
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync("config.xml");
            }
            using (var fs = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                serializer.Serialize(fs.AsStreamForWrite(), this);
            }
        }
        private static string GetCurrentPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
    }
}
