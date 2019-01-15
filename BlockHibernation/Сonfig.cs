using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockHibernation
{
    /// <summary>
    /// Кофигурация приложения.
    /// </summary>
    public class Config
    {
        private static Config _instance;

        private Config() { }
        public static Config GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Config();
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
        public void Save()
        {

        }
    }
}
